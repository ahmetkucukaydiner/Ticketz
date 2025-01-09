using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketz.Application.Features.Flights.Queries.SearchFlight;

namespace Ticketz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SearchFlights([FromBody] SearchFlightQuery query)
        {
            List<SearchFlightQueryResponse> response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
