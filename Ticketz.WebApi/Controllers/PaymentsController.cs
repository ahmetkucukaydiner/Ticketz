using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketz.Application.Features.Payment.Commands;

namespace Ticketz.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePaymentCommand createPaymentCommand)
    {
        CreatedPaymentResponse response = await _mediator.Send(createPaymentCommand);
        return Ok(response);
    }
} 