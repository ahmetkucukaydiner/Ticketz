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
using Ticketz.Application.Services.SearchFlightService;

namespace Ticketz.Application.Features.Flights.Queries;

public class SearchFlightQuery : IRequest<List<SearchFlightResponse>>, ICachableRequest, ILoggableRequest
{
    public FlightSearchCriteriaDto SearchFlightCriteria { get; set; }

    public string CacheKey => "SearchFlightQuery";
    public bool BypassCache { get; }
    public string? CacheGroupKey => throw new NotImplementedException();
    public TimeSpan? SlidingExpiration { get; }

    public class SearchFlightQueryHandler : IRequestHandler<SearchFlightQuery, List<SearchFlightResponse>>
    {
        private readonly ISearchFlightService _searchFlightService;
        private readonly IMapper _mapper;

        public SearchFlightQueryHandler(ISearchFlightService searchFlightService, IMapper mapper)
        {
            _searchFlightService = searchFlightService;
            _mapper = mapper;
        }

        public async Task<List<SearchFlightResponse>> Handle(SearchFlightQuery request, CancellationToken cancellationToken)
        {
            var flights = await _searchFlightService.SearchFlightAsync(request.SearchFlightCriteria);

            var response = _mapper.Map<List<SearchFlightResponse>>(flights);

            return response;
        }
    }
}
