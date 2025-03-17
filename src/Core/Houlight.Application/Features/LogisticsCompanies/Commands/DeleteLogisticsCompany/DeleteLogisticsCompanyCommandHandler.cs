using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.DeleteLogisticsCompany;

public class DeleteLogisticsCompanyCommandHandler : IRequestHandler<DeleteLogisticsCompanyCommand, bool>
{
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;

    public DeleteLogisticsCompanyCommandHandler(ILogisticsCompanyRepository logisticsCompanyRepository)
    {
        _logisticsCompanyRepository = logisticsCompanyRepository;
    }

    public async Task<bool> Handle(DeleteLogisticsCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _logisticsCompanyRepository.GetByIdAsync(request.Id);
        
        if (company == null)
            throw new Exception("Lojistik şirketi bulunamadı.");

        var result = await _logisticsCompanyRepository.DeleteAsync(company);
        return result > 0;
    }
} 