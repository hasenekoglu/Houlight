using MediatR;

namespace Houlight.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<UpdateCustomerCommandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public class UpdateCustomerCommandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime UpdatedDate { get; set; }
} 