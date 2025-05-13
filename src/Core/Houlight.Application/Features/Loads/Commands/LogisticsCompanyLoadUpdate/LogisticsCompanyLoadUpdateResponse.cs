using Houlight.Domain.Enums;

namespace Houlight.Application.Features.Loads.Commands.LogisticsCompanyLoadUpdate;

public class LogisticsCompanyLoadUpdateResponse
{
    public Guid Id { get; set; }
    public LoadStatus Status { get; set; }
} 