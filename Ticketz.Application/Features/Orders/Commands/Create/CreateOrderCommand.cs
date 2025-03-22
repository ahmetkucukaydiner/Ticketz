using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Customers.Commands.Create;
using Ticketz.Application.Features.Flights.Commands.Create;
using Ticketz.Application.Features.Payment.Commands;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;
using Ticketz.Domain.Enums;

namespace Ticketz.Application.Features.Orders.Commands.Create;

public class CreateOrderCommand : IRequest<CreatedOrderResponse>, ILoggableRequest, ICacheRemoverRequest, ITransactionalRequest
{
    public int AirlineId { get; set; }
    public decimal Price { get; set; }
    public OrderState OrderState { get; set; } = OrderState.Sales;
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerPassportNumber { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public string CustomerEmail { get; set; }
    public int FlightNumber { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int AdultPassengers { get; set; }
    public string? CabinClass { get; set; }
    public string? BrandedFareName { get; set; }
    public string? Luggage { get; set; }
    public int DepartureAirportId { get; set; }
    public int ArrivalAirportId { get; set; }
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpirationDate { get; set; }
    public string Cvv { get; set; }

    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetOrder";

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreatedOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IAirlineRepository _airlineRepository;
        private readonly IAirportRepository _airportRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository, 
            ICustomerRepository customerRepository,
            IFlightRepository flightRepository,
            IAirlineRepository airlineRepository,
            IAirportRepository airportRepository,
            IMediator mediator,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _flightRepository = flightRepository;
            _airlineRepository = airlineRepository;
            _airportRepository = airportRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CreatedOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = request.CustomerFirstName,
                LastName = request.CustomerLastName,
                PassportNumber = request.CustomerPassportNumber,
                PhoneNumber = request.CustomerPhoneNumber,
                Email = request.CustomerEmail
            };
            
            await _customerRepository.AddAsync(customer);
            
            var flight = new Flight
            {
                AirlineId = request.AirlineId,
                DepartureAirportId = request.DepartureAirportId,
                ArrivalAirportId = request.ArrivalAirportId,
                FlightNumber = request.FlightNumber,
                DepartureTime = request.DepartureTime,
                ArrivalTime = request.ArrivalTime,
                Price = request.Price,
                AdultPassengers = request.AdultPassengers,
                CabinClass = request.CabinClass,
                BrandedFareName = request.BrandedFareName,
                Luggage = request.Luggage
            };
            
            await _flightRepository.AddAsync(flight);
            
            var order = new Order
            {
                CustomerId = customer.Id,
                AirlineId = request.AirlineId,
                FlightId = flight.Id,
                Price = request.Price,
                OrderState = request.OrderState,
                PaymentId = 0 
            };
            
            await _orderRepository.AddAsync(order);
            
            var createPaymentCommand = new CreatePaymentCommand
            {
                OrderId = order.Id,
                CardNumber = request.CardNumber,
                CardHolderName = request.CardHolderName,
                ExpirationDate = request.ExpirationDate,
                Cvv = request.Cvv,
                Price = request.Price
            };
            
            var paymentResponse = await _mediator.Send(createPaymentCommand, cancellationToken);
            
            if (!paymentResponse.IsSuccessful)
            {
                await _orderRepository.UpdateAsync(order);
                throw new Exception("Ödeme işlemi başarısız oldu.");
            }
            
            order.PaymentId = paymentResponse.Id;
            await _orderRepository.UpdateAsync(order);

            var airline = await _airlineRepository.GetAsync(a => a.Id == request.AirlineId);
            var departureAirport = await _airportRepository.GetAsync(a => a.Id == request.DepartureAirportId);
            var arrivalAirport = await _airportRepository.GetAsync(a => a.Id == request.ArrivalAirportId);

            CreatedOrderResponse response = _mapper.Map<CreatedOrderResponse>(order);
            
            response.CustomerFullName = $"{customer.FirstName} {customer.LastName}";
            response.CustomerEmail = customer.Email;
            response.CustomerPhoneNumber = customer.PhoneNumber;
            response.CustomerPassportNumber = customer.PassportNumber;
            
            response.FlightNumber = flight.FlightNumber;
            response.DepartureTime = flight.DepartureTime;
            response.ArrivalTime = flight.ArrivalTime;
            response.CabinClass = flight.CabinClass;
            response.Luggage = flight.Luggage;
            
            if (airline != null)
            {
                response.AirlineName = airline.Name;
            }           
                       
            response.PaymentId = paymentResponse.PaymentId;
            response.PaymentDate = paymentResponse.PaymentDate;
            response.IsPaymentSuccessful = paymentResponse.IsSuccessful;

            return response;
        }
    }
}