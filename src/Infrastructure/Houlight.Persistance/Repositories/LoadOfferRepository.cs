using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using Houlight.Persistence.Context;
using Houlight.Persistence.Repositories;

namespace Houlight.Persistence.Repositories;

public class LoadOfferRepository : GenericRepository<LoadOfferEntity>, ILoadOfferRepository
{
    public LoadOfferRepository(HoulightDbContext context) : base(context)
    {
    }
} 