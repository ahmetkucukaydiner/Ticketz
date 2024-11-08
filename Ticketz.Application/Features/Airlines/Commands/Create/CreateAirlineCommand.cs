using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Airlines.Rules;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Airlines.Commands.Create;

public class CreateAirlineCommand : IRequest<CreatedAirlineResponse>, ILoggableRequest, ICacheRemoverRequest
{
    public string Name { get; set; }
    public string IATACode { get; set; }
    public Uri LogoURL { get; set; }
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetAirline";

    public class CreateAirlineCommandHandler : IRequestHandler<CreateAirlineCommand, CreatedAirlineResponse>
    {
        private readonly IAirlineRepository _airlineRepository;
        private readonly IMapper _mapper;
        private readonly AirlineBusinessRules _airlineBusinessRules;

        public CreateAirlineCommandHandler(AirlineBusinessRules airlineBusinessRules, IAirlineRepository airlineRepository, IMapper mapper)
        {
            _airlineBusinessRules = airlineBusinessRules;
            _airlineRepository = airlineRepository;
            _mapper = mapper;
        }

        public async Task<CreatedAirlineResponse> Handle(CreateAirlineCommand request, CancellationToken cancellationToken)
        {
            await _airlineBusinessRules.AirlineNameCannotBeDuplicatedWhenInserted(request.Name);

            Airline? airline = _mapper.Map<Airline>(request);

            await _airlineRepository.AddAsync(airline);

            CreatedAirlineResponse createdAirlineResponse = _mapper.Map<CreatedAirlineResponse>(airline);

            return createdAirlineResponse;
        }
    }
}
