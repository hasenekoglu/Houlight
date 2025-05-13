using FluentValidation;

namespace Houlight.Application.Features.LogisticsCompanies.Commands.ChangePassword;

public class ChangeCompanyPasswordCommandValidator : AbstractValidator<ChangeCompanyPasswordCommand>
{
    public ChangeCompanyPasswordCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Şirket ID'si boş olamaz.");

        RuleFor(x => x.CurrentPassword)
            .NotEmpty().WithMessage("Mevcut şifre boş olamaz.");

        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("Yeni şifre boş olamaz.")
            .MinimumLength(6).WithMessage("Yeni şifre en az 6 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Yeni şifre en fazla 50 karakter olabilir.")
            .Matches("[A-Z]").WithMessage("Yeni şifre en az bir büyük harf içermelidir.")
            .Matches("[a-z]").WithMessage("Yeni şifre en az bir küçük harf içermelidir.")
            .Matches("[0-9]").WithMessage("Yeni şifre en az bir rakam içermelidir.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Yeni şifre en az bir özel karakter içermelidir.");
    }
} 