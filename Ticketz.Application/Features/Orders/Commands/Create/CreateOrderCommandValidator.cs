using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.Features.Orders.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.ArrivalAirportId).NotNull();
        RuleFor(x => x.DepartureAirportId).NotNull();
        RuleFor(x => x.Price).NotEmpty();
    }
}
