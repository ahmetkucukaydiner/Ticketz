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
using Ticketz.Application.Features.Airports.Commands.Create;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Flights.Commands.Create
{
    public class CreateFlightCommand : IRequest<CreatedFlightResponse> , ITransactionalRequest, ILoggableRequest
    {
        public int AirlineId { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public int AdultPassengers { get; set; }
        public string? CabinClass { get; set; }
        public string? BrandedFareName { get; set; }
        public string? Luggage { get; set; }

        public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, CreatedFlightResponse>
        {
            private readonly IFlightRepository _flightRepository;
            private readonly IMapper _mapper;

            public CreateFlightCommandHandler(IMapper mapper, IFlightRepository flightRepository)
            {
                _mapper = mapper;
                _flightRepository = flightRepository;
            }

            public async Task<CreatedFlightResponse> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
            {
                Flight flight = _mapper.Map<Flight>(request);

                await _flightRepository.AddAsync(flight);

                CreatedFlightResponse createdFlightResponse = _mapper.Map<CreatedFlightResponse>(flight);

                return createdFlightResponse;
            }
        }
    }
}