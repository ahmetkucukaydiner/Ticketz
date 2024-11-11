using Core.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.DTOs.FlightDto;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;
using Ticketz.Infrastructure.BookingFlightApi;
using Ticketz.Persistence.Context;

namespace Ticketz.Persistence.Repositories;

public class FlightRepository : EfRepositoryBase<Flight, int, BaseDbContext>, IFlightRepository
{
    private readonly BookingFlightService _bookingFlightService;
    public FlightRepository(BaseDbContext context, BookingFlightService bookingFlightService) : base(context)
    {
        _bookingFlightService = bookingFlightService;
    }

    public async Task<List<Flight>> SearchFlightAsync(FlightSearchCriteriaDto searchCriteria)
    {
        return await _bookingFlightService.SearchFlightAsync(searchCriteria);
    }
}
