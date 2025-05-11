using MediatR;
using Houlight.Application.Services.Auth;
using Houlight.Application.Interfaces.Repositories;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.Login;

public class LoginCompanyCommandHandler : IRequestHandler<LoginCompanyCommand, LoginCompanyResponse>
{
    private readonly IAuthService _authService;

    public LoginCompanyCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCompanyResponse> Handle(LoginCompanyCommand request, CancellationToken cancellationToken)
    {
       var (success, token, companyId) = await _authService.LoginCompanyAsync(request.Email, request.Password);

        return new LoginCompanyResponse
        {
            Success = success,
            Token = token,
            Message = success ? "Giriş başarılı" : "E-posta veya şifre hatalı"
        };
    }
} 