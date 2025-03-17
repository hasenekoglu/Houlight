using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.DeleteLogisticsCompany;

public class DeleteLogisticsCompanyCommand : IRequest<bool>
{
    public Guid Id { get; set; }
} 