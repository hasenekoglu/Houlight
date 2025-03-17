using AutoMapper;
using Houlight.Application.Features.LogisticsCompanies.Commands.CreateLogisticsCompany;
using Houlight.Application.Features.LogisticsCompanies.Commands.UpdateLogisticsCompany;
using Houlight.Application.Features.LogisticsCompanies.Queries.GetAllLogisticsCompanies;
using Houlight.Application.Features.LogisticsCompanies.Queries.GetLogisticsCompaniesByFilter;
using Houlight.Application.Features.LogisticsCompanies.Queries.GetLogisticsCompanyById;
using Houlight.Domain.Entities;

namespace Houlight.Application.Mapping;

public class LogisticsCompanyMappingProfile : Profile
{
    public LogisticsCompanyMappingProfile()
    {
        CreateMap<LogisticsCompanyEntity, CreateLogisticsCompanyResponse>();
        CreateMap<LogisticsCompanyEntity, UpdateLogisticsCompanyResponse>();
        CreateMap<LogisticsCompanyEntity, GetLogisticsCompanyByIdResponse>();
        CreateMap<LogisticsCompanyEntity, GetAllLogisticsCompaniesResponse>();
        CreateMap<LogisticsCompanyEntity, GetLogisticsCompaniesByFilterResponse>();
    }
} 