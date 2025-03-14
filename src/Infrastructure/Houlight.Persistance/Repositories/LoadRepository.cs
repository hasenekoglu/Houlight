using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using Houlight.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Persistence.Repositories;

public class LoadRepository : GenericRepository<LoadEntity>, ILoadRepository
{
    public LoadRepository(HoulightDbContext dbContext) : base(dbContext)
    {
    }
}