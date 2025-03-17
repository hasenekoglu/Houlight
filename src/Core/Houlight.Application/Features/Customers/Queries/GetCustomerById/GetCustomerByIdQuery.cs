using MediatR;

namespace Houlight.Application.Features.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQuery : IRequest<GetCustomerByIdResponse>
{
    public Guid Id { get; set; }
}

public class GetCustomerByIdResponse
{
    public Guid Id { get; set; }
   public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
} 