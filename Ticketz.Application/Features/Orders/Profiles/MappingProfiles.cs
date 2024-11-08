using AutoMapper;
using Core.Application.Responses;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Orders.Commands.Create;
using Ticketz.Application.Features.Orders.Commands.Delete;
using Ticketz.Application.Features.Orders.Commands.Update;
using Ticketz.Application.Features.Orders.Queries.GetById;
using Ticketz.Application.Features.Orders.Queries.GetList;
using Ticketz.Application.Features.Orders.Queries.GetListByDynamic;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Orders.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Order, GetListOrderListItemDto>().ReverseMap();
        CreateMap<Paginate<Order>, GetListResponse<GetListOrderListItemDto>>().ReverseMap();
        CreateMap<Paginate<Order>, GetListResponse<GetListByDynamicOrderListItemDto>>().ReverseMap();
        CreateMap<Order, GetListByDynamicOrderListItemDto>().ReverseMap();

        CreateMap<Order, GetByIdOrderQuery>().ReverseMap();
        CreateMap<Order, GetByIdOrderResponse>().ReverseMap();

        CreateMap<Order, CreatedOrderResponse>().ReverseMap();
        CreateMap<Order, CreateOrderCommand>().ReverseMap();

        CreateMap<Order, DeletedOrderResponse>().ReverseMap();
        CreateMap<Order, DeleteOrderCommand>().ReverseMap();

        CreateMap<Order, UpdatedOrderResponse>().ReverseMap();
        CreateMap<Order, UpdateOrderCommand>().ReverseMap();

    }
}
