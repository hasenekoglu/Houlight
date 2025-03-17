using MediatR;

namespace Houlight.Application.Features.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<bool>
{
    public Guid Id { get; set; }
} 