﻿using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;
using Ticketz.Persistence.Context;

namespace Ticketz.Persistence.Repositories;

public class CustomerRepository : EfRepositoryBase<Customer, int, BaseDbContext>, ICustomerRepository
{
    public CustomerRepository(BaseDbContext context) : base(context)
    {
    }
}
