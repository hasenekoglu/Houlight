using MediatR;

namespace Houlight.Application.Features.Customers.Commands.Login;

public class LoginCustomerCommand : IRequest<LoginCustomerResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
} 