using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;
using Ticketz.Domain.Enums;

namespace Ticketz.Application.Features.Orders.Commands.Update;

public class UpdateOrderCommand : IRequest<UpdatedOrderResponse>, ILoggableRequest, ICacheRemoverRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int AgencyId { get; set; }
    public int AirlineId { get; set; }
    public int ArrivalAirportId { get; set; }
    public int DepartureAirportId { get; set; }
    public decimal Price { get; set; }
    public OrderState OrderState { get; set; }

    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetOrder";

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdatedOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedOrderResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetAsync(x => x.Id == request.Id);

            order = _mapper.Map(request, order);

            await _orderRepository.UpdateAsync(order);

            UpdatedOrderResponse response = _mapper.Map<UpdatedOrderResponse>(order);

            return response;
        }
    }
}
