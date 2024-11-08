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

namespace Ticketz.Application.Features.Airports.Commands.Update;

public class UpdateAirportCommand : IRequest<UpdatedAirportResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AirportCode { get; set; }
    public string Country { get; set; }

    public string CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetAirport";

    public class UpdateAirportCommandHandler : IRequestHandler<UpdateAirportCommand, UpdatedAirportResponse>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;

        public UpdateAirportCommandHandler(IMapper mapper, IAirportRepository airportRepository)
        {
            _mapper = mapper;
            _airportRepository = airportRepository;
        }

        public async Task<UpdatedAirportResponse> Handle(UpdateAirportCommand request, CancellationToken cancellationToken)
        {
            Airport? airport = await _airportRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);

            airport = _mapper.Map(request, airport);

            await _airportRepository.UpdateAsync(airport);

            var response = _mapper.Map<UpdatedAirportResponse>(airport);

            return response;
        }
    }
}
