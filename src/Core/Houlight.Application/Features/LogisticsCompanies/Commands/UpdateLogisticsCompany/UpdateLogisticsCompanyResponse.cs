namespace Houlight.Application.Features.LogisticsCompanies.Commands.UpdateLogisticsCompany;

public class UpdateLogisticsCompanyResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public string CompanyPhoneNumber { get; set; }
    public string CompanyEmail { get; set; }
    public DateTime UpdateDate { get; set; }
} 