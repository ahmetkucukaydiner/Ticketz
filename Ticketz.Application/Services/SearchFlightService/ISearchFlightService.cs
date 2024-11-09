using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.DTOs.FlightDto;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Services.SearchFlightService;

public interface ISearchFlightService
{
    Task<List<Flight>> SearchFlightAsync(FlightSearchCriteriaDto searchCriteria);
}
