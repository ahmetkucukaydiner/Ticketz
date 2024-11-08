using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Orders.Queries.GetList;

public class GetListOrderQuery : IRequest<GetListResponse<GetListOrderListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListOrderQuery({PageRequest.PageIndex}, {PageRequest.PageSize})";
    public bool BypassCache { get; }
    public string? CacheGroupKey => throw new NotImplementedException();
    public TimeSpan? SlidingExpiration { get; }

    public class GetListOrderQueryHandler : IRequestHandler<GetListOrderQuery, GetListResponse<GetListOrderListItemDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetListOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<GetListResponse<GetListOrderListItemDto>> Handle(GetListOrderQuery request, CancellationToken cancellationToken)
        {
            Paginate<Order> orders = await _orderRepository.GetListAsync(
                include: o => o.Include(o => o.Airline),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize);

            var response = _mapper.Map<GetListResponse<GetListOrderListItemDto>>(orders);

            return response;
        }
    }
}
