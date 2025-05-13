using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.ChangePassword;

public class ChangeCompanyPasswordCommand : IRequest<ChangeCompanyPasswordCommandResponse>
{
    public Guid Id { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}

public class ChangeCompanyPasswordCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
} 