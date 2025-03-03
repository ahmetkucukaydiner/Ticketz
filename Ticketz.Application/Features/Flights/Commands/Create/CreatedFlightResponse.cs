using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.Features.Flights.Commands.Create
{
    public class CreatedFlightResponse
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
    }
}
