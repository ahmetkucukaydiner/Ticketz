using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.DTOs.FlightDto;
using Ticketz.Application.Features.SearchFlights.Queries.GetFlightDetails;
using Ticketz.Application.Features.SearchFlights.Queries.SearchFlight;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Services.SearchFlightService;

public interface ISearchFlightService
{
    Task<List<SearchFlightQueryResponse>> SearchFlightAsync(FlightSearchCriteriaDto searchCriteria);

    //Task<GetFlightDetailsQueryResponse> GetFlightDetails(string token);
}
