﻿using AutoMapper;
using Core.Application.Responses;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Airports.Commands.Create;
using Ticketz.Application.Features.Airports.Commands.Delete;
using Ticketz.Application.Features.Airports.Commands.Update;
using Ticketz.Application.Features.Airports.Queries.GetById;
using Ticketz.Application.Features.Airports.Queries.GetList;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Airports.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Airport, CreateAirportCommand>().ReverseMap();
        CreateMap<Airport, CreatedAirportResponse>().ReverseMap();

        CreateMap<Airport, GetListAirportListItemDto>().ReverseMap();
        CreateMap<Paginate<Airport>, GetListResponse<GetListAirportListItemDto>>().ReverseMap();

        CreateMap<Airport, GetByIdAirportResponse>().ReverseMap();

        CreateMap<Airport, UpdatedAirportResponse>().ReverseMap();
        CreateMap<Airport, UpdateAirportCommand>().ReverseMap();

        CreateMap<Airport, DeletedAirportResponse>().ReverseMap();
        CreateMap<Airport, DeleteAirportCommand>().ReverseMap();
    }
}
