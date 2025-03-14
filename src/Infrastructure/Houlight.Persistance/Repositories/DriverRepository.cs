using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using Houlight.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Persistence.Repositories;

public class DriverRepository : GenericRepository<DriverEntity>, IDriverRepository
{
    public DriverRepository(HoulightDbContext dbContext) : base(dbContext)
    {
    }
}