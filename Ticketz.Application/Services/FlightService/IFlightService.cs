using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.DTOs.FlightDto;
using Ticketz.Application.Features.Flights.Queries.SearchFlight;
using Ticketz.Application.Features.SearchFlights.Queries.GetFlightDetails;


namespace Ticketz.Application.Services.FlightService;

public interface IFlightService
{
    Task<List<SearchFlightQueryResponse>> SearchFlightAsync(FlightSearchCriteriaDto searchCriteria);
    Task<GetFlightDetailsQueryResponse> GetFlightDetails(GetDetailsOfSelectedFlightDto token);
}
