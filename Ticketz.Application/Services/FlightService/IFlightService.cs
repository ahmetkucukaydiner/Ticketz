using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.DTOs.FlightDto;
using Ticketz.Application.Features.Flights.Queries.SearchFlight;


namespace Ticketz.Application.Services.FlightService;

public interface IFlightService
{
    Task<List<SearchFlightQueryResponse>> SearchFlightAsync(FlightSearchCriteriaDto searchCriteria);

    //Task<GetFlightDetailsQueryResponse> GetFlightDetails(string token);
}
