using AutoMapper;
using FluentValidation;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Application.Services.Auth;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.CreateLogisticsCompany;

public class CreateLogisticsCompanyCommandHandler : IRequestHandler<CreateLogisticsCompanyCommand, CreateLogisticsCompanyResponse>
{
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;
    private readonly IMapper _mapper;
    private readonly CreateLogisticsCompanyCommandValidator _validator;
    private readonly IAuthService _authService;

    public CreateLogisticsCompanyCommandHandler(
        ILogisticsCompanyRepository logisticsCompanyRepository,
        IMapper mapper,
        CreateLogisticsCompanyCommandValidator validator,
        IAuthService authService)
    {
        _logisticsCompanyRepository = logisticsCompanyRepository;
        _mapper = mapper;
        _validator = validator;
        _authService = authService;
    }

    public async Task<CreateLogisticsCompanyResponse> Handle(CreateLogisticsCompanyCommand request, CancellationToken cancellationToken)
    {
        // E-posta kontrolü
        var existingCompany = await _logisticsCompanyRepository.GetByEmailAsync(request.CompanyEmail);
        if (existingCompany != null)
        {
            throw new ValidationException("Bu e-posta adresi zaten kullanılıyor. Lütfen başka bir e-posta adresi deneyin.");
        }

        var company = new LogisticsCompanyEntity
        {
            CompanyName = request.CompanyName,
            CompanyAddress = request.CompanyAddress,
            CompanyPhoneNumber = request.CompanyPhoneNumber,
            CompanyEmail = request.CompanyEmail
        };

        // Şifre hash'leme işlemi
        var (passwordHash, passwordSalt) = _authService.CreatePasswordHash(request.Password);
        company.PasswordHash = passwordHash;
        company.PasswordSalt = passwordSalt;

        await _logisticsCompanyRepository.AddAsync(company);

        return _mapper.Map<CreateLogisticsCompanyResponse>(company);
    }
} 