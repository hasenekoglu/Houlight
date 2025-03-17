using FluentValidation;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.CreateLogisticsCompany;

public class CreateLogisticsCompanyCommandValidator : AbstractValidator<CreateLogisticsCompanyCommand>
{
    public CreateLogisticsCompanyCommandValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("Şirket adı boş olamaz.")
            .MaximumLength(100).WithMessage("Şirket adı 100 karakterden uzun olamaz.");

        RuleFor(x => x.CompanyAddress)
            .NotEmpty().WithMessage("Şirket adresi boş olamaz.")
            .MaximumLength(200).WithMessage("Şirket adresi 200 karakterden uzun olamaz.");

        RuleFor(x => x.CompanyEmail)
            .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
            .MaximumLength(50).WithMessage("E-posta adresi 50 karakterden uzun olamaz.");

        RuleFor(x => x.CompanyPhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
            .Matches(@"^[0-9]+$").WithMessage("Telefon numarası sadece rakamlardan oluşmalıdır.")
            .Length(11).WithMessage("Telefon numarası 11 haneli olmalıdır.");
    }
} 