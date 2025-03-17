using MediatR;

namespace Houlight.Application.Features.Customers.Queries.GetCustomersByFilter;

public class GetCustomersByFilterQuery : IRequest<List<GetCustomersByFilterResponse>>
{
    public string? SearchTerm { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}

public class GetCustomersByFilterResponse
{
    public Guid Id { get; set; }
     public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
} 