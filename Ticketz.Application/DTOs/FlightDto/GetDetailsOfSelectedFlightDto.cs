using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.DTOs.FlightDto
{
    public class GetDetailsOfSelectedFlightDto
    {
        public string token { get; set; }
        public string? currency_code { get; set; } = "TRY";
    }
}