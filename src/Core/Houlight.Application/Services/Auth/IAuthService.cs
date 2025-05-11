using System;
using System.Threading.Tasks;
using Houlight.Domain.Entities;

namespace Houlight.Application.Services.Auth;

public interface IAuthService
{
    (string passwordHash, string passwordSalt) CreatePasswordHash(string password);
    bool VerifyPasswordHash(string password, string storedHash, string storedSalt);
    Task<(bool success, string token, Guid customerId)> LoginCustomerAsync(string email, string password);
    Task<(bool success, string token, Guid companyId)> LoginCompanyAsync(string email, string password);
    Task<bool> RegisterCustomerAsync(CustomerEntity customer, string password);
    Task<bool> RegisterCompanyAsync(LogisticsCompanyEntity company, string password);
    Task<bool> ChangePasswordAsync(string email, string currentPassword, string newPassword);
    Task<bool> ResetPasswordAsync(string email);
} 