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

namespace Ticketz.Application.Features.Orders.Queries.GetById;

public class GetByIdOrderQuery : IRequest<GetByIdOrderResponse>, ILoggableRequest, ICachableRequest
{
    public int Id { get; set; }
    public string CacheKey => "GetByIdOrderQuery";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetOrder";
    public TimeSpan? SlidingExpiration { get; }

    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, GetByIdOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetByIdOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdOrderResponse> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
        {
            Order? order = await _orderRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            GetByIdOrderResponse response = _mapper.Map<GetByIdOrderResponse>(order);

            return response;
        }
    }
}
