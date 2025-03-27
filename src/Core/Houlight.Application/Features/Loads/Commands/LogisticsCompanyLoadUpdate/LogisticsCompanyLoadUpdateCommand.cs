using MediatR;

namespace Houlight.Application.Features.Loads.Commands.LogisticsCompanyLoadUpdate;

public class LogisticsCompanyLoadUpdateCommand : IRequest<LogisticsCompanyLoadUpdateResponse>
{
    public Guid Id { get; set; }
    public decimal CompanyOfferedPrice { get; set; }
    public Guid LogisticsCompanyId { get; set; }
    public Guid? AssignedVehicleId { get; set; }
    public Guid? AssignedDriverId { get; set; }
} 