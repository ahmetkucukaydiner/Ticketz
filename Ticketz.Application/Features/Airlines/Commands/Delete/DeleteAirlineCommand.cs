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

namespace Ticketz.Application.Features.Airlines.Commands.Delete;

public class DeleteAirlineCommand : IRequest<DeletedAirlineResponse>, ILoggableRequest, ICacheRemoverRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IATACode { get; set; }

    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetAirline";

    public class DeleteAirlineCommandHandler : IRequestHandler<DeleteAirlineCommand, DeletedAirlineResponse>
    {
        private readonly IAirlineRepository _airlineRepository;
        private readonly IMapper _mapper;

        public DeleteAirlineCommandHandler(IAirlineRepository airlineRepository, IMapper mapper)
        {
            _airlineRepository = airlineRepository;
            _mapper = mapper;
        }

        public async Task<DeletedAirlineResponse> Handle(DeleteAirlineCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Airline? airline = await _airlineRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            await _airlineRepository.DeleteAsync(airline);

            DeletedAirlineResponse response = _mapper.Map<DeletedAirlineResponse>(airline);

            return response;
        }
    }
}
