using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using Houlight.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Persistence.Repositories;

public class CustomerRepository : GenericRepository<CustomerEntity>, ICustomerRepository
{
    public CustomerRepository(HoulightDbContext dbContext) : base(dbContext)
    {
    }
}