using Houlight.Domain.Entities;

namespace Houlight.Application.Interfaces.Repositories;

public interface ILogisticsCompanyRepository : IGenericRepository<LogisticsCompanyEntity>
{
    Task<LogisticsCompanyEntity?> GetByEmailAsync(string email);
}