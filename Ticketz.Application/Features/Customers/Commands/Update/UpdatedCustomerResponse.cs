﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.Features.Customers.Commands.Update;

public class UpdatedCustomerResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
