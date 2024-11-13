using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.SearchFlights.Queries.SearchFlight;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.SearchFlights.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Flight, List<SearchFlightQueryResponse>>().ReverseMap();
        CreateMap<Flight, SearchFlightQuery>().ReverseMap();
        CreateMap<Flight, SearchFlightQueryResponse>().ReverseMap();
    }
}
