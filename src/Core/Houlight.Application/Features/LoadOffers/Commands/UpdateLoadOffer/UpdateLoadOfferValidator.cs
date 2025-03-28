using FluentValidation;

namespace Houlight.Application.Features.LoadOffers.Commands.UpdateLoadOffer;

public class UpdateLoadOfferValidator : AbstractValidator<UpdateLoadOfferCommand>
{
    public UpdateLoadOfferValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Teklif ID boş olamaz");

        RuleFor(x => x.CompanyOfferedPrice)
            .GreaterThan(0).WithMessage("Teklif edilen fiyat 0'dan büyük olmalıdır");
    }
} 