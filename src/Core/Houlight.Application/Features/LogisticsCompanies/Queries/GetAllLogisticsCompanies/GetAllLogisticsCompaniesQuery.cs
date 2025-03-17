using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Queries.GetAllLogisticsCompanies;

public class GetAllLogisticsCompaniesQuery : IRequest<List<GetAllLogisticsCompaniesResponse>>
{
}

public class GetAllLogisticsCompaniesResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public string CompanyPhoneNumber { get; set; }
    public string CompanyEmail { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
} 