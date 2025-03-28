using MediatR;

namespace Houlight.Application.Features.LoadOffers.Commands.UpdateLoadOffer;

public class UpdateLoadOfferCommand : IRequest<UpdateLoadOfferResponse>
{
    public Guid Id { get; set; }
    public decimal CompanyOfferedPrice { get; set; }
    public Guid? AssignedVehicleId { get; set; }
    public Guid? AssignedDriverId { get; set; }
} 