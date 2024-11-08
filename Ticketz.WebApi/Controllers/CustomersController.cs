using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketz.Application.Features.Customers.Commands.Create;
using Ticketz.Application.Features.Customers.Commands.Delete;
using Ticketz.Application.Features.Customers.Commands.Update;
using Ticketz.Application.Features.Customers.Queries.GetById;
using Ticketz.Application.Features.Customers.Queries.GetList;

namespace Ticketz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createCustomerCommand)
    {
        CreatedCustomerResponse createCustomerResponse = await Mediator.Send(createCustomerCommand);
        return Ok(createCustomerResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
    {
        UpdatedCustomerResponse updateCustomerResponse = await Mediator.Send(updateCustomerCommand);
        return Ok(updateCustomerResponse);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerResponse deleteCustomerResponse = await Mediator.Send(new DeleteCustomerCommand { Id = id });
        return Ok(deleteCustomerResponse);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerResponse getByIdCustomerResponse = await Mediator.Send(new GetByIdCustomerQuery { Id = id });
        return Ok(getByIdCustomerResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerQuery getListCustomerQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerListItemDto> getListCustomerListItemDto = await Mediator.Send(getListCustomerQuery);
        return Ok(getListCustomerListItemDto);
    }
}
