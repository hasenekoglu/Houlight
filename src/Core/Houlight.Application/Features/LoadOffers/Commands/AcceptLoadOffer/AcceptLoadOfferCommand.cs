using MediatR;

namespace Houlight.Application.Features.LoadOffers.Commands.AcceptLoadOffer;

public class AcceptLoadOfferCommand : IRequest<AcceptLoadOfferResponse>
{
    public Guid LoadOfferId { get; set; }
} 