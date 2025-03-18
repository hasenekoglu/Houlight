using FluentValidation;

namespace Houlight.Application.Features.Drivers.Commands.UpdateDriver;

public class UpdateDriverValidator : AbstractValidator<UpdateDriverCommand>
{
    public UpdateDriverValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad boş olamaz.")
            .MaximumLength(50).WithMessage("Ad 50 karakterden uzun olamaz.");

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Soyad boş olamaz.")
            .MaximumLength(50).WithMessage("Soyad 50 karakterden uzun olamaz.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
            .Matches(@"^[0-9]{10}$").WithMessage("Geçersiz telefon numarası formatı.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
            .EmailAddress().WithMessage("Geçersiz e-posta adresi formatı.")
            .MaximumLength(100).WithMessage("E-posta adresi 100 karakterden uzun olamaz.");

        RuleFor(x => x.LicenseNumber)
            .NotEmpty().WithMessage("Ehliyet numarası boş olamaz.")
            .Matches(@"^[0-9]{11}$").WithMessage("Geçersiz ehliyet numarası formatı.");

        //RuleFor(x => x.LicenseType)
        //    .NotEmpty().WithMessage("Ehliyet tipi boş olamaz.")
        //    .MaximumLength(20).WithMessage("Ehliyet tipi 20 karakterden uzun olamaz.");

        //RuleFor(x => x.LicenseExpiryDate)
        //    .NotEmpty().WithMessage("Ehliyet son kullanma tarihi boş olamaz.")
        //    .GreaterThan(DateTime.Now).WithMessage("Ehliyet son kullanma tarihi bugünden sonra olmalıdır.");
    }
} 