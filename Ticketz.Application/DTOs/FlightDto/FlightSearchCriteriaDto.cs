using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.DTOs.FlightDto;

public class FlightSearchCriteriaDto
{
    private string _fromId;
    private string _toId;

    public string fromId 
    { 
        get=> $"{_fromId}.AIRPORT"; 
        set => _fromId = value; 
    }
    public string toId 
    {
        get => $"{_toId}.AIRPORT";
        set => _toId = value;
    }
    public DateTime departDate { get; set; }
    public int adults { get; set; } = 1;
    public string Sort { get; set; }
    public string? cabinClass { get; set; } = "ECONOMY";
    public string? currency_code { get; set; } = "TRY";
}
