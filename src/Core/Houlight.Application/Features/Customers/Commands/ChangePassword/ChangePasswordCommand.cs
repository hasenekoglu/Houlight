using MediatR;

namespace Houlight.Application.Features.Customers.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest<ChangePasswordCommandResponse>
{
    public Guid Id { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}

public class ChangePasswordCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
} 