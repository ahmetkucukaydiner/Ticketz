using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.DTOs.FlightDto;
using Ticketz.Application.Services.Repositories;
using Ticketz.Application.Services.SearchFlightService;

namespace Ticketz.Application.Features.Flights.Queries;

public class SearchFlightQuery : IRequest<List<SearchFlightResponse>>, ICachableRequest, ILoggableRequest
{
    public FlightSearchCriteriaDto SearchFlightCriteria { get; set; }

    public string CacheKey => $"SearchFlightQuery{SearchFlightCriteria.DepartureAirport}-{SearchFlightCriteria.ArrivalAirport}-{SearchFlightCriteria.DepartDate}-{SearchFlightCriteria.AdultPassengers}";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "SearchFlight";
    public TimeSpan? SlidingExpiration { get; }

    public class SearchFlightQueryHandler : IRequestHandler<SearchFlightQuery, List<SearchFlightResponse>>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public SearchFlightQueryHandler(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<List<SearchFlightResponse>> Handle(SearchFlightQuery request, CancellationToken cancellationToken)
        {
            var flights = await _flightRepository.SearchFlightAsync(request.SearchFlightCriteria);

            var response = _mapper.Map<List<SearchFlightResponse>>(flights);

            return response;
        }
    }
}
