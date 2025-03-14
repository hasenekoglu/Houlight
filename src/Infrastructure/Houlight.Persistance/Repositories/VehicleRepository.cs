using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using Houlight.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Persistence.Repositories;

public class VehicleRepository : GenericRepository<VehicleEntity>, IVehicleRepository
{
    public VehicleRepository(HoulightDbContext dbContext) : base(dbContext)
    {
    }
}