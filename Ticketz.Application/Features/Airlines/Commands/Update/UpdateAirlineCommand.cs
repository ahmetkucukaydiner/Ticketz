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

namespace Ticketz.Application.Features.Airlines.Commands.Update;

public class UpdateAirlineCommand : IRequest<UpdatedAirlineResponse>, ILoggableRequest, ICacheRemoverRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IATACode { get; set; }

    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetAirline";

    public class UpdateAirlineCommandHandler : IRequestHandler<UpdateAirlineCommand, UpdatedAirlineResponse>
    {
        private readonly IAirlineRepository _airlineRepository;
        private readonly IMapper _mapper;

        public UpdateAirlineCommandHandler(IAirlineRepository airlineRepository, IMapper mapper)
        {
            _airlineRepository = airlineRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedAirlineResponse> Handle(UpdateAirlineCommand request, CancellationToken cancellationToken)
        {
            Airline? airline = await _airlineRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            airline = _mapper.Map(request, airline);

            await _airlineRepository.UpdateAsync(airline);

            UpdatedAirlineResponse response = _mapper.Map<UpdatedAirlineResponse>(airline);

            return response;
        }
    }
}
