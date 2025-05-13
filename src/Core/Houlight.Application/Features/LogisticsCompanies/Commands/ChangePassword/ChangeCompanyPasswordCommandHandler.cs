using FluentValidation;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Application.Services.Auth;
using MediatR;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.ChangePassword;

public class ChangeCompanyPasswordCommandHandler : IRequestHandler<ChangeCompanyPasswordCommand, ChangeCompanyPasswordCommandResponse>
{
    private readonly ILogisticsCompanyRepository _companyRepository;
    private readonly ChangeCompanyPasswordCommandValidator _validator;
    private readonly IAuthService _authService;

    public ChangeCompanyPasswordCommandHandler(
        ILogisticsCompanyRepository companyRepository,
        ChangeCompanyPasswordCommandValidator validator,
        IAuthService authService)
    {
        _companyRepository = companyRepository;
        _validator = validator;
        _authService = authService;
    }

    public async Task<ChangeCompanyPasswordCommandResponse> Handle(ChangeCompanyPasswordCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var company = await _companyRepository.GetByIdAsync(request.Id);
        if (company == null)
            throw new Exception("Şirket bulunamadı.");

        // Mevcut şifreyi kontrol et
        if (!_authService.VerifyPasswordHash(request.CurrentPassword, company.PasswordHash, company.PasswordSalt))
            throw new Exception("Mevcut şifre yanlış.");

        // Yeni şifreyi hashle ve kaydet
        var (passwordHash, passwordSalt) = _authService.CreatePasswordHash(request.NewPassword);
        company.PasswordHash = passwordHash;
        company.PasswordSalt = passwordSalt;
        company.UpdateDate = DateTime.Now;

        await _companyRepository.UpdateAsync(company);

        return new ChangeCompanyPasswordCommandResponse
        {
            Success = true,
            Message = "Şifre başarıyla değiştirildi."
        };
    }
} 