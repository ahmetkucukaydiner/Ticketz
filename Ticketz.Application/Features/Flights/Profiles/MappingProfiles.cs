using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Flights.Commands.Create;
using Ticketz.Application.Features.Flights.Queries.SearchFlight;
using Ticketz.Application.Features.Orders.Commands.Create;
using Ticketz.Application.Features.SearchFlights.Queries.GetFlightDetails;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Flights.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Flight, List<SearchFlightQueryResponse>>().ReverseMap();
        CreateMap<Flight, SearchFlightQuery>().ReverseMap();
        CreateMap<Flight, SearchFlightQueryResponse>().ReverseMap();
        CreateMap<Flight, GetFlightDetailsQuery>().ReverseMap();
        CreateMap<Flight, GetFlightDetailsQueryResponse>().ReverseMap();
        CreateMap<Flight, List<GetFlightDetailsQueryResponse>>().ReverseMap();

        CreateMap<Flight, CreatedFlightResponse>().ReverseMap();
        CreateMap<Flight, CreateFlightCommand>().ReverseMap();
    }
}
