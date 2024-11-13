using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.Features.SearchFlights.Queries.SearchFlight
{
    public class SearchFlightQueryResponse
    {
        public int AirlineId { get; set; }
        public Uri AirlineLogo { get; set; }
        public string AirlineName { get; set; }
        public int DepartureAirportId { get; set; }
        public string DepartureAirportName { get; set; }
        public int ArrivalAirportId { get; set; }
        public string ArrivalAirportName { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public int AdultPassengers { get; set; }
        public string? CabinClass { get; set; }
        public string? BrandedFareName { get; set; }
        public string? Luggage { get; set; }
        public string Token { get; set; }
    }
}
