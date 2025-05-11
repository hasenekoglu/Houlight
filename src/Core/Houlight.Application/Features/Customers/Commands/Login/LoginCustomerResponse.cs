namespace Houlight.Application.Features.Customers.Commands.Login;

public class LoginCustomerResponse
{
      public bool Success { get; set; }
    public string Token { get; set; }
    public string Message { get; set; }
    public Guid UserId { get; set; }
} 