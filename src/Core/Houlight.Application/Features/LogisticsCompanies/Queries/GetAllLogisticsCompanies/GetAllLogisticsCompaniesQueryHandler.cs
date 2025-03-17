using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Queries.GetAllLogisticsCompanies;

public class GetAllLogisticsCompaniesQueryHandler : IRequestHandler<GetAllLogisticsCompaniesQuery, List<GetAllLogisticsCompaniesResponse>>
{
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;
    private readonly IMapper _mapper;

    public GetAllLogisticsCompaniesQueryHandler(ILogisticsCompanyRepository logisticsCompanyRepository, IMapper mapper)
    {
        _logisticsCompanyRepository = logisticsCompanyRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllLogisticsCompaniesResponse>> Handle(GetAllLogisticsCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _logisticsCompanyRepository.GetAll();
        return _mapper.Map<List<GetAllLogisticsCompaniesResponse>>(companies);
    }
} 