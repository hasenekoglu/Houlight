using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Queries.GetLogisticsCompanyById;

public class GetLogisticsCompanyByIdQueryHandler : IRequestHandler<GetLogisticsCompanyByIdQuery, GetLogisticsCompanyByIdResponse>
{
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;
    private readonly IMapper _mapper;

    public GetLogisticsCompanyByIdQueryHandler(ILogisticsCompanyRepository logisticsCompanyRepository, IMapper mapper)
    {
        _logisticsCompanyRepository = logisticsCompanyRepository;
        _mapper = mapper;
    }

    public async Task<GetLogisticsCompanyByIdResponse> Handle(GetLogisticsCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _logisticsCompanyRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetLogisticsCompanyByIdResponse>(company);
    }
} 