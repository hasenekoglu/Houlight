using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.UpdateLogisticsCompany;

public class UpdateLogisticsCompanyCommandHandler : IRequestHandler<UpdateLogisticsCompanyCommand, UpdateLogisticsCompanyResponse>
{
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateLogisticsCompanyCommandHandler> _logger;

    public UpdateLogisticsCompanyCommandHandler(
        ILogisticsCompanyRepository logisticsCompanyRepository, 
        IMapper mapper,
        ILogger<UpdateLogisticsCompanyCommandHandler> logger)
    {
        _logisticsCompanyRepository = logisticsCompanyRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UpdateLogisticsCompanyResponse> Handle(UpdateLogisticsCompanyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Lojistik şirket güncelleme işlemi başladı. Şirket ID: {CompanyId}", request.Id);

            var company = await _logisticsCompanyRepository.GetByIdAsync(request.Id, false);
            
            if (company == null)
            {
                _logger.LogWarning("Lojistik şirket bulunamadı. Şirket ID: {CompanyId}", request.Id);
                throw new Exception("Lojistik şirketi bulunamadı.");
            }

            _logger.LogInformation("Mevcut şirket bilgileri: {@Company}", company);

            // Telefon numarası kontrolü
            if (!request.CompanyPhoneNumber.StartsWith("0") || request.CompanyPhoneNumber.Length != 11)
            {
                _logger.LogWarning("Geçersiz telefon numarası formatı: {PhoneNumber}", request.CompanyPhoneNumber);
                throw new Exception("Telefon numarası 0 ile başlamalı ve 11 haneli olmalıdır.");
            }

            // E-posta kontrolü
            if (await _logisticsCompanyRepository.GetByEmailAsync(request.CompanyEmail) is var existingCompany 
                && existingCompany != null 
                && existingCompany.Id != request.Id)
            {
                _logger.LogWarning("Bu e-posta adresi başka bir şirket tarafından kullanılıyor: {Email}", request.CompanyEmail);
                throw new Exception("Bu e-posta adresi başka bir şirket tarafından kullanılıyor.");
            }

            // Güncelleme işlemi
            company.CompanyName = request.CompanyName.Trim();
            company.CompanyAddress = request.CompanyAddress.Trim();
            company.CompanyEmail = request.CompanyEmail.Trim().ToLower();
            company.CompanyPhoneNumber = request.CompanyPhoneNumber.Trim();
            company.UpdateDate = DateTime.UtcNow;

            _logger.LogInformation("Güncellenecek şirket bilgileri: {@Company}", company);

            var updateResult = await _logisticsCompanyRepository.UpdateAsync(company);
            
            if (updateResult <= 0)
            {
                _logger.LogError("Şirket güncellenirken bir hata oluştu. Şirket ID: {CompanyId}", request.Id);
                throw new Exception("Şirket bilgileri güncellenirken bir hata oluştu.");
            }

            _logger.LogInformation("Şirket başarıyla güncellendi. Şirket ID: {CompanyId}", request.Id);

            var response = _mapper.Map<UpdateLogisticsCompanyResponse>(company);
            _logger.LogInformation("Güncelleme yanıtı: {@Response}", response);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Şirket güncellenirken beklenmeyen bir hata oluştu. Şirket ID: {CompanyId}", request.Id);
            throw;
        }
    }
} 