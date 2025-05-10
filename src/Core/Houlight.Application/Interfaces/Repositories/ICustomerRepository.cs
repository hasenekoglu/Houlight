using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Houlight.Domain.Entities;

namespace Houlight.Application.Interfaces.Repositories;

public interface ICustomerRepository : IGenericRepository<CustomerEntity>
{
    Task<CustomerEntity?> GetByEmailAsync(string email);
}