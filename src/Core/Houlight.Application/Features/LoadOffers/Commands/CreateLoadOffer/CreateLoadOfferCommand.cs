using MediatR;

namespace Houlight.Application.Features.LoadOffers.Commands.CreateLoadOffer;

public class CreateLoadOfferCommand : IRequest<CreateLoadOfferResponse>
{
    public Guid LoadId { get; set; }
    public decimal CompanyOfferedPrice { get; set; }
    public Guid LogisticsCompanyId { get; set; }
    public Guid? AssignedVehicleId { get; set; }
    public Guid? AssignedDriverId { get; set; }
} 