using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketz.Application.Features.Airports.Commands.Create;
using Ticketz.Application.Features.Airports.Commands.Delete;
using Ticketz.Application.Features.Airports.Commands.Update;
using Ticketz.Application.Features.Airports.Queries.GetById;
using Ticketz.Application.Features.Airports.Queries.GetList;

namespace Ticketz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AirportsController : BaseController
{

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAirportCommand createAirportCommand)
    {
        CreatedAirportResponse createdAirportResponse = await Mediator.Send(createAirportCommand);
        return Ok(createdAirportResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAirportQuery getListAirportQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAirportListItemDto> response = await Mediator.Send(getListAirportQuery);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAirportQuery getByIdAirportQuery = new() { Id = id };
        GetByIdAirportResponse response = await Mediator.Send(getByIdAirportQuery);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAirportCommand updateAirportCommand)
    {
        UpdatedAirportResponse response = await Mediator.Send(updateAirportCommand);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAirportResponse response = await Mediator.Send(new DeleteAirportCommand { Id = id });
        return Ok(response);
    }
}
