using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.Login;

public class LoginCompanyCommand : IRequest<LoginCompanyResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
} 