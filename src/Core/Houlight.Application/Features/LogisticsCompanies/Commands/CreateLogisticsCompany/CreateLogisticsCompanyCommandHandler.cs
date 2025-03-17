using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.CreateLogisticsCompany;

public class CreateLogisticsCompanyCommandHandler : IRequestHandler<CreateLogisticsCompanyCommand, CreateLogisticsCompanyResponse>
{
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;
    private readonly IMapper _mapper;

    public CreateLogisticsCompanyCommandHandler(ILogisticsCompanyRepository logisticsCompanyRepository, IMapper mapper)
    {
        _logisticsCompanyRepository = logisticsCompanyRepository;
        _mapper = mapper;
    }

    public async Task<CreateLogisticsCompanyResponse> Handle(CreateLogisticsCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new LogisticsCompanyEntity
        {
            CompanyName = request.CompanyName,
            CompanyAddress = request.CompanyAddress,
            CompanyEmail = request.CompanyEmail,
            CompanyPhoneNumber = request.CompanyPhoneNumber
        };

        await _logisticsCompanyRepository.AddAsync(company);

        return _mapper.Map<CreateLogisticsCompanyResponse>(company);
    }
} 