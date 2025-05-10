using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Houlight.Domain.Entities;
using Houlight.Application.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace Houlight.Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;

    public AuthService(
        IConfiguration configuration,
        ICustomerRepository customerRepository,
        ILogisticsCompanyRepository logisticsCompanyRepository)
    {
        _configuration = configuration;
        _customerRepository = customerRepository;
        _logisticsCompanyRepository = logisticsCompanyRepository;
    }

    public async Task<(bool success, string token)> LoginCustomerAsync(string email, string password)
    {
        var customer = await _customerRepository.GetByEmailAsync(email);
        if (customer == null) return (false, null);

        if (!VerifyPasswordHash(password, customer.PasswordHash, customer.PasswordSalt))
            return (false, null);

        var token = GenerateToken(customer.Id.ToString(), "customer");
        return (true, token);
    }

    public async Task<(bool success, string token)> LoginCompanyAsync(string email, string password)
    {
        var company = await _logisticsCompanyRepository.GetByEmailAsync(email);
        if (company == null) return (false, null);

        if (!VerifyPasswordHash(password, company.PasswordHash, company.PasswordSalt))
            return (false, null);

        var token = GenerateToken(company.Id.ToString(), "company");
        return (true, token);
    }

    public async Task<bool> RegisterCustomerAsync(CustomerEntity customer, string password)
    {
        if (await _customerRepository.GetByEmailAsync(customer.Email) != null)
            return false;

        var (passwordHash, passwordSalt) = CreatePasswordHash(password);
        customer.PasswordHash = passwordHash;
        customer.PasswordSalt = passwordSalt;

        await _customerRepository.AddAsync(customer);
        return true;
    }

    public async Task<bool> RegisterCompanyAsync(LogisticsCompanyEntity company, string password)
    {
        if (await _logisticsCompanyRepository.GetByEmailAsync(company.CompanyEmail) != null)
            return false;

        var (passwordHash, passwordSalt) = CreatePasswordHash(password);
        company.PasswordHash = passwordHash;
        company.PasswordSalt = passwordSalt;

        await _logisticsCompanyRepository.AddAsync(company);
        return true;
    }

    public async Task<bool> ChangePasswordAsync(string email, string currentPassword, string newPassword)
    {
        var customer = await _customerRepository.GetByEmailAsync(email);
        if (customer != null)
        {
            if (!VerifyPasswordHash(currentPassword, customer.PasswordHash, customer.PasswordSalt))
                return false;

            var (passwordHash, passwordSalt) = CreatePasswordHash(newPassword);
            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;

            return true;
        }

        var company = await _logisticsCompanyRepository.GetByEmailAsync(email);
        if (company != null)
        {
            if (!VerifyPasswordHash(currentPassword, company.PasswordHash, company.PasswordSalt))
                return false;

            var (passwordHash, passwordSalt) = CreatePasswordHash(newPassword);
            company.PasswordHash = passwordHash;
            company.PasswordSalt = passwordSalt;

            return true;
        }

        return false;
    }

    public async Task<bool> ResetPasswordAsync(string email)
    {
        // TODO: Implement password reset logic with email service
        return true;
    }

    public (string passwordHash, string passwordSalt) CreatePasswordHash(string password)
    {
        using var hmac = new HMACSHA512();
        var passwordSalt = Convert.ToBase64String(hmac.Key);
        var passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        return (passwordHash, passwordSalt);
    }

    public bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
    {
        var saltBytes = Convert.FromBase64String(storedSalt);
        using var hmac = new HMACSHA512(saltBytes);
        var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        return computedHash == storedHash;
    }

    private string GenerateToken(string userId, string userType)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Role, userType)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
} 