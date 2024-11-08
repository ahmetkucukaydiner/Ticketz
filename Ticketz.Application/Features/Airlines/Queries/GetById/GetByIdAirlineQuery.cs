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

namespace Ticketz.Application.Features.Airlines.Queries.GetById;

public class GetByIdAirlineQuery : IRequest<GetByIdAirlineResponse>, ILoggableRequest, ICachableRequest
{
    public int Id { get; set; }

    public string CacheKey => $"GetByIdAirlineQuery({Id})";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetAirline";
    public TimeSpan? SlidingExpiration { get; }

    public class GetByIdAirlineQueryHandler : IRequestHandler<GetByIdAirlineQuery, GetByIdAirlineResponse>
    {
        private readonly IAirlineRepository _airlineRepository;
        private readonly IMapper _mapper;

        public GetByIdAirlineQueryHandler(IAirlineRepository airlineRepository, IMapper mapper)
        {
            _airlineRepository = airlineRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdAirlineResponse> Handle(GetByIdAirlineQuery request, CancellationToken cancellationToken)
        {
            Airline airline = await _airlineRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            GetByIdAirlineResponse response = _mapper.Map<GetByIdAirlineResponse>(airline);
            return response;
        }
    }
}
