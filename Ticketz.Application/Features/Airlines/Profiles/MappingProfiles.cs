using AutoMapper;
using Core.Application.Responses;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Airlines.Commands.Create;
using Ticketz.Application.Features.Airlines.Commands.Delete;
using Ticketz.Application.Features.Airlines.Commands.Update;
using Ticketz.Application.Features.Airlines.Queries.GetById;
using Ticketz.Application.Features.Airlines.Queries.GetList;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Airlines.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Airline, CreateAirlineCommand>().ReverseMap();
        CreateMap<Airline, CreatedAirlineResponse>().ReverseMap();

        CreateMap<Airline, DeleteAirlineCommand>().ReverseMap();
        CreateMap<Airline, DeletedAirlineResponse>().ReverseMap();

        CreateMap<Airline, UpdateAirlineCommand>().ReverseMap();
        CreateMap<Airline, UpdatedAirlineResponse>().ReverseMap();

        CreateMap<Airline, GetByIdAirlineResponse>().ReverseMap();

        CreateMap<Airline, GetListAirlineQuery>().ReverseMap();
        CreateMap<Paginate<Airline>, GetListResponse<GetListAirlineListItemDto>>().ReverseMap();
    }
}
