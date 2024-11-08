using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.Features.Airlines.Commands.Create;

public class CreateAirlineCommandValidator : AbstractValidator<CreateAirlineCommand>
{
    public CreateAirlineCommandValidator()
    {
        RuleFor(a => a.IATACode).NotEmpty().MinimumLength(2);
        RuleFor(a => a.Name).NotEmpty().MinimumLength(4);
    }
}
