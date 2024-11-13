using Core.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;
using Ticketz.Persistence.Context;

namespace Ticketz.Persistence.Repositories;

public class FlightRepository : EfRepositoryBase<Flight, int, BaseDbContext>, IFlightRepository
{
    public FlightRepository(BaseDbContext context) : base(context)
    {
        
    }
}
