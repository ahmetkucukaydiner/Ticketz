using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Airports.Queries.GetById;

public class GetByIdAirportQuery : IRequest<GetByIdAirportResponse>, ILoggableRequest, ICachableRequest
{
    public int Id { get; set; }

    public string CacheKey => "GetByIdAirportQuery";

    public bool BypassCache { get; }

    public string? CacheGroupKey => "GetAirport";

    public TimeSpan? SlidingExpiration { get; }

    public class GetByIdAirportQueryHandler : IRequestHandler<GetByIdAirportQuery, GetByIdAirportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAirportRepository _airportRepository;

        public GetByIdAirportQueryHandler(IAirportRepository airportRepository, IMapper mapper)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdAirportResponse> Handle(GetByIdAirportQuery request, CancellationToken cancellationToken)
        {
            Airport? airport = await _airportRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);

            GetByIdAirportResponse getByIdAirportResponse = _mapper.Map<GetByIdAirportResponse>(airport);

            return getByIdAirportResponse;
        }
    }
}
