using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.DTOs.FlightDto;
using Ticketz.Application.Features.SearchFlights.Queries.GetFlightDetails;
using Ticketz.Application.Features.SearchFlights.Queries.SearchFlight;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Services.Repositories;

public interface IFlightRepository : IAsyncRepository<Flight, int>, IRepository<Flight, int>
{
}
