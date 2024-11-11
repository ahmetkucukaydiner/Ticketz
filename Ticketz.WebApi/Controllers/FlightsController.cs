using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketz.Application.Features.Flights.Queries;

namespace Ticketz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SearchFlights([FromBody] SearchFlightQuery query)
        {
            List<SearchFlightResponse> response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
