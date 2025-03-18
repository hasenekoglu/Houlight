using MediatR;
using Houlight.Domain.Enums;

namespace Houlight.Application.Features.Drivers.Queries.GetDriversByFilter;

public class GetDriversByFilterQuery : IRequest<List<GetDriversByFilterResponse>>
{
    public string? SearchTerm { get; set; }
    public string? LicenseNumber { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DriverStatus? DriverStatus { get; set; }
    public Guid? LogisticsCompanyId { get; set; }
}

public class GetDriversByFilterResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string LicenseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DriverStatus DriverStatus { get; set; }
    public Guid LogisticsCompanyId { get; set; }
    public string LogisticsCompanyName { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
} 