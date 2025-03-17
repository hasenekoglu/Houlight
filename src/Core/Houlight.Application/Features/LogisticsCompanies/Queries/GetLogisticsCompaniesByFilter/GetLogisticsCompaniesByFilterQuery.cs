using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Queries.GetLogisticsCompaniesByFilter;

public class GetLogisticsCompaniesByFilterQuery : IRequest<List<GetLogisticsCompaniesByFilterResponse>>
{
    public string? SearchTerm { get; set; }
    public string? CompanyEmail { get; set; }
    public string? CompanyPhoneNumber { get; set; }
    public string? CompanyName { get; set; }
}

public class GetLogisticsCompaniesByFilterResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public string CompanyPhoneNumber { get; set; }
    public string CompanyEmail { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
} 