using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.UpdateLogisticsCompany;

public class UpdateLogisticsCompanyCommandHandler : IRequestHandler<UpdateLogisticsCompanyCommand, UpdateLogisticsCompanyResponse>
{
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;
    private readonly IMapper _mapper;

    public UpdateLogisticsCompanyCommandHandler(ILogisticsCompanyRepository logisticsCompanyRepository, IMapper mapper)
    {
        _logisticsCompanyRepository = logisticsCompanyRepository;
        _mapper = mapper;
    }

    public async Task<UpdateLogisticsCompanyResponse> Handle(UpdateLogisticsCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _logisticsCompanyRepository.GetByIdAsync(request.Id);
        
        if (company == null)
            throw new Exception("Lojistik şirketi bulunamadı.");

        company.CompanyName = request.CompanyName;
        company.CompanyAddress = request.CompanyAddress;
        company.CompanyEmail = request.CompanyEmail;
        company.CompanyPhoneNumber = request.CompanyPhoneNumber;

        await _logisticsCompanyRepository.UpdateAsync(company);

        return _mapper.Map<UpdateLogisticsCompanyResponse>(company);
    }
} 