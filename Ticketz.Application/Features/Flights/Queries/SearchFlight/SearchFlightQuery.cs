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
using Ticketz.Application.Services.FlightService;

namespace Ticketz.Application.Features.Flights.Queries.SearchFlight;

public class SearchFlightQuery : IRequest<List<SearchFlightQueryResponse>>, ICachableRequest, ILoggableRequest
{
    public FlightSearchCriteriaDto SearchFlightCriteria { get; set; }

    public string CacheKey => $"SearchFlightQuery{SearchFlightCriteria.fromId}-{SearchFlightCriteria.toId}-{SearchFlightCriteria.departDate}-{SearchFlightCriteria.adults}";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "SearchFlight";
    public TimeSpan? SlidingExpiration { get; }

    public class SearchFlightQueryHandler : IRequestHandler<SearchFlightQuery, List<SearchFlightQueryResponse>>
    {
        private readonly IFlightService _searchflightService;
        private readonly IMapper _mapper;

        public SearchFlightQueryHandler(IFlightService searchflightService, IMapper mapper)
        {
            _searchflightService = searchflightService;
            _mapper = mapper;
        }

        public async Task<List<SearchFlightQueryResponse>> Handle(SearchFlightQuery request, CancellationToken cancellationToken)
        {
            var flights = await _searchflightService.SearchFlightAsync(request.SearchFlightCriteria);

            var response = _mapper.Map<List<SearchFlightQueryResponse>>(flights);

            return response;
        }
    }
}
