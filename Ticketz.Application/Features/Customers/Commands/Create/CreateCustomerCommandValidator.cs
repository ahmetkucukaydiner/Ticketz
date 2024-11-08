using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.Features.Customers.Commands.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MinimumLength(7).EmailAddress();
        RuleFor(x => x.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(x => x.LastName).NotEmpty().MinimumLength(2);
        RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(10);
        RuleFor(x => x.PassportNumber).NotEmpty().MinimumLength(6);
    }
}
