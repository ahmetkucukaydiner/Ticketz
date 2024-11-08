using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Airports.Queries.GetList;

public class GetListAirportQuery : IRequest<GetListResponse<GetListAirportListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListAirportQuery({PageRequest.PageIndex}, {PageRequest.PageSize})";
    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string? CacheGroupKey => "GetAirport";

    public class GetListAirportQueryHandler : IRequestHandler<GetListAirportQuery, GetListResponse<GetListAirportListItemDto>>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;

        public GetListAirportQueryHandler(IMapper mapper, IAirportRepository airportRepository)
        {
            _mapper = mapper;
            _airportRepository = airportRepository;
        }

        public async Task<GetListResponse<GetListAirportListItemDto>> Handle(GetListAirportQuery request, CancellationToken cancellationToken)
        {
            Paginate<Airport> airports = await _airportRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );

            GetListResponse<GetListAirportListItemDto> response = _mapper.Map<GetListResponse<GetListAirportListItemDto>>(airports);

            return response;
        }
    }
}
