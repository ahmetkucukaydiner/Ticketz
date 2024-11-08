using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.Features.Airlines.Commands.Create;

public class CreatedAirlineResponse
{
    public string Name { get; set; }
    public string IATACode { get; set; }
}
