﻿using AutoMapper;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Services.PaymentService;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Payment.Commands;

public class CreatePaymentCommand : IRequest<CreatedPaymentResponse>, ILoggableRequest, ITransactionalRequest
{
    public int OrderId { get; set; }
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpirationDate { get; set; }
    public string Cvv { get; set; }
    public decimal Price { get; set; }

    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatedPaymentResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public CreatePaymentCommandHandler(
            IPaymentRepository paymentRepository,
            IPaymentService paymentService,
            IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<CreatedPaymentResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentResult = await _paymentService.ProcessPayment(
                request.CardNumber,
                request.CardHolderName,
                request.ExpirationDate,
                request.Cvv,
                request.Price,
                cancellationToken);

            if (!paymentResult.IsSuccessful)
            {
                throw new Exception($"Ödeme işlemi başarısız: {paymentResult.ErrorMessage}");
            }

            var payment = new Domain.Entities.Payment
            {
                OrderId = request.OrderId,
                CardNumber = MaskCardNumber(request.CardNumber),
                CardHolderName = request.CardHolderName,
                ExpirationDate = request.ExpirationDate,
                Cvv = "***",
                Price = request.Price
            };

            await _paymentRepository.AddAsync(payment);

            var response = _mapper.Map<CreatedPaymentResponse>(payment);
            response.PaymentId = paymentResult.PaymentId;
            response.PaymentDate = paymentResult.PaymentDate;
            response.IsSuccessful = true;

            return response;
        }

        private string MaskCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
                return string.Empty;

            cardNumber = cardNumber.Replace(" ", "").Replace("-", "");
            if (cardNumber.Length < 4)
                return cardNumber;

            return "XXXX-XXXX-XXXX-" + cardNumber.Substring(cardNumber.Length - 4);
        }
    }
}
