using FluentValidation;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.CreateLogisticsCompany;

public class CreateLogisticsCompanyCommandValidator : AbstractValidator<CreateLogisticsCompanyCommand>
{
    public CreateLogisticsCompanyCommandValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("Şirket adı alanı boş olamaz.")
            .MaximumLength(100).WithMessage("Şirket adı 100 karakterden uzun olamaz.");

        RuleFor(x => x.CompanyAddress)
            .NotEmpty().WithMessage("Şirket adresi alanı boş olamaz.")
            .MaximumLength(200).WithMessage("Şirket adresi 200 karakterden uzun olamaz.");

        RuleFor(x => x.CompanyPhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası alanı boş olamaz.")
            .Matches(@"^[0-9]+$").WithMessage("Telefon numarası sadece rakamlardan oluşmalıdır.")
            .Length(10).WithMessage("Telefon numarası 10 haneli olmalıdır.");

        RuleFor(x => x.CompanyEmail)
            .NotEmpty().WithMessage("E-posta alanı boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
            .MaximumLength(100).WithMessage("E-posta alanı 100 karakterden uzun olamaz.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre alanı boş olamaz.")
            .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Şifre 50 karakterden uzun olamaz.");
    }
} 