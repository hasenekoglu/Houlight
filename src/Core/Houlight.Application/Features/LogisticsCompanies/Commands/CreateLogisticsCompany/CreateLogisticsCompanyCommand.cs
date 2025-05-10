using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.CreateLogisticsCompany;

public class CreateLogisticsCompanyCommand : IRequest<CreateLogisticsCompanyResponse>
{
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public string CompanyPhoneNumber { get; set; }
    public string CompanyEmail { get; set; }
    //public string TaxNumber { get; set; }
    public string Password { get; set; }
}

public class CreateLogisticsCompanyResponse
{
    //public bool Success { get; set; }
    //public string Message { get; set; }
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public string CompanyPhoneNumber { get; set; }
    public string CompanyEmail { get; set; }
    //public string TaxNumber { get; set; }
    public DateTime CreateDate { get; set; }
} 