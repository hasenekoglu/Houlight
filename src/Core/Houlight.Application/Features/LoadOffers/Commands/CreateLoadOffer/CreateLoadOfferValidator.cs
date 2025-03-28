using FluentValidation;

namespace Houlight.Application.Features.LoadOffers.Commands.CreateLoadOffer;

public class CreateLoadOfferValidator : AbstractValidator<CreateLoadOfferCommand>
{
    public CreateLoadOfferValidator()
    {
        RuleFor(x => x.LoadId)
            .NotEmpty().WithMessage("Yük ID boş olamaz");

        RuleFor(x => x.CompanyOfferedPrice)
            .GreaterThan(0).WithMessage("Teklif edilen fiyat 0'dan büyük olmalıdır");

        RuleFor(x => x.LogisticsCompanyId)
            .NotEmpty().WithMessage("Lojistik şirket ID boş olamaz");
    }
} 