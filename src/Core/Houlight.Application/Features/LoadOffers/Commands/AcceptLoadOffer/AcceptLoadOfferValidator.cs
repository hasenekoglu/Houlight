using FluentValidation;

namespace Houlight.Application.Features.LoadOffers.Commands.AcceptLoadOffer;

public class AcceptLoadOfferValidator : AbstractValidator<AcceptLoadOfferCommand>
{
    public AcceptLoadOfferValidator()
    {
        RuleFor(x => x.LoadOfferId)
            .NotEmpty().WithMessage("Teklif ID boş olamaz");
    }
} 