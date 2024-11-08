using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketz.Application.Features.Airlines.Commands.Create;
using Ticketz.Application.Features.Airlines.Commands.Delete;
using Ticketz.Application.Features.Airlines.Commands.Update;
using Ticketz.Application.Features.Airlines.Queries.GetById;
using Ticketz.Application.Features.Airlines.Queries.GetList;

namespace Ticketz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AirlinesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAirlineCommand createAirlineCommand)
    {
        CreatedAirlineResponse createdAirlineResponse = await Mediator.Send(createAirlineCommand);
        return Ok(createdAirlineResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAirlineCommand updateAirlineCommand)
    {
        UpdatedAirlineResponse updatedAirlineResponse = await Mediator.Send(updateAirlineCommand);
        return Ok(updatedAirlineResponse);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAirlineResponse deletedAirlineResponse = await Mediator.Send(new DeleteAirlineCommand { Id = id });
        return Ok(deletedAirlineResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAirlineQuery getByIdAirlineQuery = new() { Id = id };
        GetByIdAirlineResponse getByIdAirlineResponse = await Mediator.Send(getByIdAirlineQuery);
        return Ok(getByIdAirlineResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAirlineQuery getListAirlineQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAirlineListItemDto> getListAirlineListItemDto = await Mediator.Send(getListAirlineQuery);
        return Ok(getListAirlineListItemDto);
    }
}
