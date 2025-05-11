using FluentValidation;
using Houlight.Application.Interfaces.Repositories;

namespace Houlight.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Müşteri ID'si boş olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad alanı boş olamaz.")
            .MaximumLength(50).WithMessage("Ad alanı 50 karakterden uzun olamaz.");

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Soyad alanı boş olamaz.")
            .MaximumLength(50).WithMessage("Soyad alanı 50 karakterden uzun olamaz.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta alanı boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
            .MaximumLength(100).WithMessage("E-posta alanı 100 karakterden uzun olamaz.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası alanı boş olamaz.")
            .Matches(@"^[0-9]{10}$").WithMessage("Telefon numarası 10 haneli olmalıdır (Örnek: 5XX XXX XX XX)")
            .Must(phone => !phone.StartsWith("0")).WithMessage("Telefon numarası 0 ile başlamamalıdır.");
    }
} 