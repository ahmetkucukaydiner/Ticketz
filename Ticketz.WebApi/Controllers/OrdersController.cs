using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketz.Application.Features.Orders.Commands.Create;
using Ticketz.Application.Features.Orders.Commands.Delete;
using Ticketz.Application.Features.Orders.Commands.Update;
using Ticketz.Application.Features.Orders.Queries.GetById;
using Ticketz.Application.Features.Orders.Queries.GetList;
using Ticketz.Application.Features.Orders.Queries.GetListByDynamic;
using MediatR;

namespace Ticketz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : BaseController
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOrderQuery getListOrderQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListOrderListItemDto> response = await Mediator.Send(getListOrderQuery);
        return Ok(response);
    }

    [HttpPost("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery = null)
    {
        GetListByDynamicOrderQuery getListByDynamicOrderQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        GetListResponse<GetListByDynamicOrderListItemDto> response = await Mediator.Send(getListByDynamicOrderQuery);
        return Ok(response);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdOrderResponse getByIdOrderResponse = await Mediator.Send(new GetByIdOrderQuery { Id = id });
        return Ok(getByIdOrderResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand createOrderCommand)
    {
        CreatedOrderResponse response = await _mediator.Send(createOrderCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderCommand updateOrderCommand)
    {
        UpdatedOrderResponse updateOrderResponse = await Mediator.Send(updateOrderCommand);
        return Ok(updateOrderResponse);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedOrderResponse deleteOrderResponse = await Mediator.Send(new DeleteOrderCommand { Id = id });
        return Ok(deleteOrderResponse);
    }
}
