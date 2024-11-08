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

namespace Ticketz.Application.Features.Airlines.Queries.GetList
{
    public class GetListAirlineQuery : IRequest<GetListResponse<GetListAirlineListItemDto>>, ICachableRequest, ILoggableRequest
    {
        public PageRequest PageRequest { get; set; }

        public string CacheKey => $"GetListAirlineQuery({PageRequest.PageIndex}, {PageRequest.PageSize})";
        public bool BypassCache { get; }
        public string? CacheGroupKey => "GetAirline";
        public TimeSpan? SlidingExpiration { get; }

        public class GetListAirlineQueryHandler : IRequestHandler<GetListAirlineQuery, GetListResponse<GetListAirlineListItemDto>>
        {
            private readonly IAirlineRepository _airlineRepository;
            private readonly IMapper _mapper;

            public GetListAirlineQueryHandler(IAirlineRepository airlineRepository, IMapper mapper)
            {
                _airlineRepository = airlineRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListAirlineListItemDto>> Handle(GetListAirlineQuery request, CancellationToken cancellationToken)
            {
                Paginate<Domain.Entities.Airline> airlines = await _airlineRepository.GetListAsync(
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken);

                GetListResponse<GetListAirlineListItemDto> response = _mapper.Map<GetListResponse<GetListAirlineListItemDto>>(airlines);

                return response;
            }
        }
    }
}
