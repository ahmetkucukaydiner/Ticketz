﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.Features.Flights.Queries
{
    public class SearchFlightResponse
    {
        public string AirlineName { get; set; }
        public Uri AirlineLogo { get; set; }
        public string DepartureAirportName { get; set; }
        public string ArrivalAirportName { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public int AdultPassengers { get; set; }
        public string CabinClass { get; set; }
        public string Luggage { get; set; }
        public string BrandedFareName { get; set; }
    }
}
