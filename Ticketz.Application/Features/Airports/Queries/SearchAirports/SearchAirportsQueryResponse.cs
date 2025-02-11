using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.Features.Airports.Queries.SearchAirports
{
    public class SearchAirportsQueryResponse
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string AirportCode { get; set; }
        public string City { get; set; }
        public string AirportName { get; set; }
    }
}
