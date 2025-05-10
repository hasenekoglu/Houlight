using MediatR;
using Houlight.Application.Services.Auth;
using Houlight.Application.Interfaces.Repositories;

namespace Houlight.Application.Features.Customers.Commands.Login;

public class LoginCustomerCommandHandler : IRequestHandler<LoginCustomerCommand, LoginCustomerResponse>
{
    private readonly IAuthService _authService;

    public LoginCustomerCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCustomerResponse> Handle(LoginCustomerCommand request, CancellationToken cancellationToken)
    {
        var (success, token) = await _authService.LoginCustomerAsync(request.Email, request.Password);

        return new LoginCustomerResponse
        {
            Success = success,
            Token = token,
            Message = success ? "Giriş başarılı" : "E-posta veya şifre hatalı"
        };
    }
} 