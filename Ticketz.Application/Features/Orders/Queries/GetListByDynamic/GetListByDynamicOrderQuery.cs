using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Dynamic;
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

namespace Ticketz.Application.Features.Orders.Queries.GetListByDynamic;

public class GetListByDynamicOrderQuery : IRequest<GetListResponse<GetListByDynamicOrderListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicOrderQueryHandler : IRequestHandler<GetListByDynamicOrderQuery, GetListResponse<GetListByDynamicOrderListItemDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByDynamicOrderListItemDto>> Handle(GetListByDynamicOrderQuery request, CancellationToken cancellationToken)
        {
            Paginate<Order> orders = await _orderRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                include: o => o.Include(o => o.Airline),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
                );

            var response = _mapper.Map<GetListResponse<GetListByDynamicOrderListItemDto>>(orders);

            return response;
        }
    }
}
