﻿using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Services.Repositories;

public interface ICustomerRepository : IAsyncRepository<Customer, int>, IRepository<Customer, int>
{
}
