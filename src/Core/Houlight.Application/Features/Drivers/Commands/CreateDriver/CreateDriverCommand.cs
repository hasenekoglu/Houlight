using MediatR;
using Houlight.Domain.Enums;

namespace Houlight.Application.Features.Drivers.Commands.CreateDriver;

public class CreateDriverCommand : IRequest<CreateDriverResponse>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string LicenseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DriverStatus DriverStatus { get; set; }
    public Guid LogisticsCompanyId { get; set; }
}

public class CreateDriverResponse
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
} 