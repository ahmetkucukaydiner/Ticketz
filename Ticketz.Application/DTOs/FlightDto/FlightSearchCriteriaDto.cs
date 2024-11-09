using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.DTOs.FlightDto;

public class FlightSearchCriteriaDto
{
    public string DepartureAirport { get; set; }
    public string ArrivalAirport { get; set; }
    public DateTime DepartDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int AdultPassengers { get; set; } = 1;
    public string Sort { get; set; }
    public string CabinClass { get; set; } = "ECONOMY";
    public string Currency { get; set; } = "TRY";
}
