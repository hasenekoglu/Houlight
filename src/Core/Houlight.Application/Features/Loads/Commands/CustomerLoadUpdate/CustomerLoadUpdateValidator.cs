using FluentValidation;
using Houlight.Domain.Enums;

namespace Houlight.Application.Features.Loads.Commands.CustomerLoadUpdate;

public class CustomerLoadUpdateValidator : AbstractValidator<CustomerLoadUpdateCommand>
{
    public CustomerLoadUpdateValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Yük ID boş olamaz");

        RuleFor(x => x.FromLocation)
            .NotEmpty().WithMessage("Başlangıç lokasyonu boş olamaz")
            .MaximumLength(200).WithMessage("Başlangıç lokasyonu 200 karakterden uzun olamaz");

        RuleFor(x => x.ToLocation)
            .NotEmpty().WithMessage("Varış lokasyonu boş olamaz")
            .MaximumLength(200).WithMessage("Varış lokasyonu 200 karakterden uzun olamaz");

        RuleFor(x => x.LoadType)
            .IsInEnum().WithMessage("Geçersiz yük tipi");

        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage("Ağırlık 0'dan büyük olmalıdır")
            .LessThanOrEqualTo(100000).WithMessage("Ağırlık 100000 kg'dan fazla olamaz");

        RuleFor(x => x.Volume)
            .GreaterThan(0).WithMessage("Hacim 0'dan büyük olmalıdır")
            .LessThanOrEqualTo(1000).WithMessage("Hacim 1000 m³'den fazla olamaz");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama 500 karakterden uzun olamaz");

        RuleFor(x => x.DeliveryDate)
            .Must(date => date == null || date > DateTime.Now)
            .WithMessage("Teslimat tarihi geçmiş bir tarih olamaz");

        RuleFor(x => x.CustomerExpectedPrice)
            .Must(price => price == null || price > 0)
            .WithMessage("Beklenen fiyat 0'dan büyük olmalıdır");
    }
} 