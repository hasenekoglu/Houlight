using MediatR;

namespace Houlight.Application.Features.LoadOffers.Commands.DeleteLoadOffer;

public class DeleteLoadOfferCommand : IRequest<DeleteLoadOfferResponse>
{
    public Guid Id { get; set; }
} 