namespace Houlight.Application.Features.LogisticsCompanies.Commands.Login;

public class LoginCompanyResponse
{
    public bool Success { get; set; }
    public string Token { get; set; }
    public string Message { get; set; }
    public string CompanyName { get; set; }
    public Guid CompanyId { get; set; }
} 