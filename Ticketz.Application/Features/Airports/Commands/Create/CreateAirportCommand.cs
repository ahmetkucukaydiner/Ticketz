using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Airports.Rules;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Airports.Commands.Create;

public class CreateAirportCommand : IRequest<CreatedAirportResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string AirportCode { get; set; }

    public string CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetAirport";

    public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, CreatedAirportResponse>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;
        private readonly AirportBusinessRules _airportBusinessRules;

        public CreateAirportCommandHandler(IAirportRepository airportRepository, IMapper mapper, AirportBusinessRules airportBusinessRules)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
            _airportBusinessRules = airportBusinessRules;
        }

        public async Task<CreatedAirportResponse>? Handle(CreateAirportCommand request, CancellationToken cancellationToken)
        {
            await _airportBusinessRules.AirportNameCannotBeDuplicatedWhenInserted(request.Name);

            Airport airport = _mapper.Map<Airport>(request);

            await _airportRepository.AddAsync(airport);

            CreatedAirportResponse createdAirportResponse = _mapper.Map<CreatedAirportResponse>(airport);

            return createdAirportResponse;
        }
    }
}
