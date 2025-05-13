using MediatR;
using Houlight.Application.Services.Auth;
using Houlight.Application.Interfaces.Repositories;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.Login;

public class LoginCompanyCommandHandler : IRequestHandler<LoginCompanyCommand, LoginCompanyResponse>
{
    private readonly IAuthService _authService;
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;

    public LoginCompanyCommandHandler(
        IAuthService authService,
        ILogisticsCompanyRepository logisticsCompanyRepository)
    {
        _authService = authService;
        _logisticsCompanyRepository = logisticsCompanyRepository;
    }

    public async Task<LoginCompanyResponse> Handle(LoginCompanyCommand request, CancellationToken cancellationToken)
    {
        var (success, token, companyId) = await _authService.LoginCompanyAsync(request.Email, request.Password);

        if (!success)
        {
            return new LoginCompanyResponse
            {
                Success = false,
                Token = null,
                Message = "E-posta veya şifre hatalı"
            };
        }

        var company = await _logisticsCompanyRepository.GetByIdAsync(companyId);
        
        return new LoginCompanyResponse
        {
            Success = true,
            Token = token,
            Message = "Giriş başarılı",
            CompanyName = company.CompanyName,
            CompanyId = company.Id
        };
    }
} 