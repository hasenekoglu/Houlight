using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using Houlight.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Persistence.Repositories;

public class LogisticsCompanyRepository : GenericRepository<LogisticsCompanyEntity>, ILogisticsCompanyRepository
{
    public LogisticsCompanyRepository(HoulightDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<LogisticsCompanyEntity?> GetByEmailAsync(string email)
    {
        return await FirstOrDefaultAsync(x => x.CompanyEmail == email);
    }
}