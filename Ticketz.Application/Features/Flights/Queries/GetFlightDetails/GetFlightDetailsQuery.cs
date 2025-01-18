using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.DTOs.FlightDto;
using Ticketz.Application.Services.FlightService;

namespace Ticketz.Application.Features.SearchFlights.Queries.GetFlightDetails;

public class GetFlightDetailsQuery : IRequest<GetFlightDetailsQueryResponse>, ILoggableRequest, ICachableRequest
{
    public GetDetailsOfSelectedFlightDto? GetDetailsOfSelectedFlight { get; set; }

    public string CacheKey => $"GetFlightDetailsQuery{GetDetailsOfSelectedFlight?.token}";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "FlightDetails";
    public TimeSpan? SlidingExpiration { get; }

    public class GetFlightDetailsQueryHandler : IRequestHandler<GetFlightDetailsQuery, GetFlightDetailsQueryResponse>
    {
        private readonly IFlightService _getDetailsOfSelectedFlightService;
        private readonly IMapper _mapper;

        public GetFlightDetailsQueryHandler(IFlightService getDetailsOfSelectedFlightService, IMapper mapper)
        {
            _getDetailsOfSelectedFlightService = getDetailsOfSelectedFlightService;
            _mapper = mapper;
        }

        public async Task<GetFlightDetailsQueryResponse> Handle(GetFlightDetailsQuery request, CancellationToken cancellationToken)
        {
            var flight = await _getDetailsOfSelectedFlightService.GetFlightDetails(request.GetDetailsOfSelectedFlight);
            var response = _mapper.Map<GetFlightDetailsQueryResponse>(flight);
            return response;
        }
    }
}
