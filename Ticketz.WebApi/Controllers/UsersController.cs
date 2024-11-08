using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketz.Application.Features.Users.Commands.Create;
using Ticketz.Application.Features.Users.Commands.Delete;
using Ticketz.Application.Features.Users.Commands.Update;
using Ticketz.Application.Features.Users.Queries.GetById;
using Ticketz.Application.Features.Users.Queries.GetList;

namespace Ticketz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
    {
        CreatedUserResponse response = await Mediator.Send(createUserCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
    {
        UpdatedUserResponse response = await Mediator.Send(updateUserCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedUserResponse deletedUserResponse = await Mediator.Send(new DeleteUserCommand { Id = id });
        return Ok(deletedUserResponse);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdUserResponse getByIdUserResponse = await Mediator.Send(new GetByIdUserQuery { Id = id });
        return Ok(getByIdUserResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserQuery query = new GetListUserQuery { PageRequest = pageRequest };
        GetListResponse<GetListUserListItemDto> getListUserListItemDto = await Mediator.Send(query);
        return Ok(getListUserListItemDto);
    }
}
