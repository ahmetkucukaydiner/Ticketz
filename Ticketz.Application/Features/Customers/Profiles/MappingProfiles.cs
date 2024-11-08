using AutoMapper;
using Core.Application.Responses;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Customers.Commands.Create;
using Ticketz.Application.Features.Customers.Commands.Delete;
using Ticketz.Application.Features.Customers.Commands.Update;
using Ticketz.Application.Features.Customers.Queries.GetById;
using Ticketz.Application.Features.Customers.Queries.GetList;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Customers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
        CreateMap<Customer, CreatedCustomerResponse>().ReverseMap();

        CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
        CreateMap<Customer, DeletedCustomerResponse>().ReverseMap();

        CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
        CreateMap<Customer, UpdatedCustomerResponse>().ReverseMap();

        CreateMap<Customer, GetByIdCustomerResponse>().ReverseMap();

        CreateMap<Customer, GetListCustomerQuery>().ReverseMap();
        CreateMap<Paginate<Customer>, GetListResponse<GetListCustomerListItemDto>>().ReverseMap();
    }
}
