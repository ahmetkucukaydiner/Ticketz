using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Airports.Queries.SearchAirports;
using Ticketz.Application.Services.Repositories;

namespace Ticketz.Application.Features.Airports.Queries.SearchAirport
{
    public class SearchAirportsQuery : IRequest<List<SearchAirportsQueryResponse>>, ILoggableRequest, ICachableRequest
    {
        public string SearchTerm { get; set; }
        public string CacheKey => $"SearchTerm : {SearchTerm}";
        public bool BypassCache { get; }
        public string? CacheGroupKey => "SearchTerm";
        public TimeSpan? SlidingExpiration { get; }


        public class SearchAirportsQueryHandler : IRequestHandler<SearchAirportsQuery, List<SearchAirportsQueryResponse>>
        {
            private readonly IAirportRepository _airportRepository;
            private readonly IMapper _mapper;

            public SearchAirportsQueryHandler(IAirportRepository airportRepository, IMapper mapper)
            {
                _airportRepository = airportRepository;
                _mapper = mapper;
            }

            public async Task<List<SearchAirportsQueryResponse>> Handle(SearchAirportsQuery request, CancellationToken cancellationToken)
            {
                return await _airportRepository.SearchAirportsAsync(request.SearchTerm);
            }
        }
    }
}
