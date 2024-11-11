using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Flights.Queries;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Flights.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Flight, List<SearchFlightResponse>>().ReverseMap();
        CreateMap<Flight, SearchFlightQuery>().ReverseMap();
        CreateMap<Flight, SearchFlightResponse>().ReverseMap();
    }
}
