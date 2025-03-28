using FluentValidation;

namespace Houlight.Application.Features.LoadOffers.Commands.DeleteLoadOffer;

public class DeleteLoadOfferValidator : AbstractValidator<DeleteLoadOfferCommand>
{
    public DeleteLoadOfferValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Teklif ID'si boş olamaz.");
    }
} 