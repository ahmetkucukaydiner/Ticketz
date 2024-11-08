using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Airports.Commands.Delete;

public class DeleteAirportCommand : IRequest<DeletedAirportResponse>, ICacheRemoverRequest
{
    public int Id { get; set; }

    public string CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetAirport";

    public class DeletedAirportCommandHandler : IRequestHandler<DeleteAirportCommand, DeletedAirportResponse>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;

        public DeletedAirportCommandHandler(IMapper mapper, IAirportRepository airportRepository)
        {
            _mapper = mapper;
            _airportRepository = airportRepository;
        }

        public async Task<DeletedAirportResponse> Handle(DeleteAirportCommand request, CancellationToken cancellationToken)
        {
            Airport? airport = await _airportRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);

            await _airportRepository.DeleteAsync(airport);

            DeletedAirportResponse response = _mapper.Map<DeletedAirportResponse>(airport);

            return response;
        }
    }
}
