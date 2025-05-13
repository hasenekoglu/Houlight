using Houlight.Domain.Enums;
using MediatR;

namespace Houlight.Application.Features.Loads.Commands.LogisticsCompanyLoadUpdate;

public class LogisticsCompanyLoadUpdateCommand : IRequest<LogisticsCompanyLoadUpdateResponse>
{
    public Guid Id { get; set; }
    public LoadStatus Status { get; set; }
    // Gerekirse CompanyId eklenebilir
} 