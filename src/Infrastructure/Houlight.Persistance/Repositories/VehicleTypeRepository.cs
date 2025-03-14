using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using Houlight.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Persistence.Repositories;

public class VehicleTypeRepository : GenericRepository<VehicleTypeEntity>, IVehicleTypeRepository
{
    public VehicleTypeRepository(HoulightDbContext dbContext) : base(dbContext)
    {
    }
}