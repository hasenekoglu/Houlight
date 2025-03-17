using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Application.Features.LogisticsCompanies.Queries.GetLogisticsCompaniesByFilter;

public class GetLogisticsCompaniesByFilterQueryHandler : IRequestHandler<GetLogisticsCompaniesByFilterQuery, List<GetLogisticsCompaniesByFilterResponse>>
{
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;
    private readonly IMapper _mapper;

    public GetLogisticsCompaniesByFilterQueryHandler(ILogisticsCompanyRepository logisticsCompanyRepository, IMapper mapper)
    {
        _logisticsCompanyRepository = logisticsCompanyRepository;
        _mapper = mapper;
    }

    public async Task<List<GetLogisticsCompaniesByFilterResponse>> Handle(GetLogisticsCompaniesByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = _logisticsCompanyRepository.AsQueryable();

        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(x => 
                x.CompanyName.ToLower().Contains(searchTerm) || 
                x.CompanyAddress.ToLower().Contains(searchTerm));
        }

        if (!string.IsNullOrEmpty(request.CompanyEmail))
        {
            query = query.Where(x => x.CompanyEmail.ToLower().Contains(request.CompanyEmail.ToLower()));
        }

        if (!string.IsNullOrEmpty(request.CompanyPhoneNumber))
        {
            query = query.Where(x => x.CompanyPhoneNumber.Contains(request.CompanyPhoneNumber));
        }

        if (!string.IsNullOrEmpty(request.CompanyName))
        {
            query = query.Where(x => x.CompanyName.ToLower().Contains(request.CompanyName.ToLower()));
        }

        var companies = await query.ToListAsync(cancellationToken);
        return _mapper.Map<List<GetLogisticsCompaniesByFilterResponse>>(companies);
    }
} 