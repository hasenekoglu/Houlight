using MediatR;

namespace Houlight.Application.Features.LoadOffers.Queries.GetLoadOfferList;

public class GetLoadOfferListQuery : IRequest<List<LoadOfferListDto>>
{
    public Guid? LoadId { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? LogisticsCompanyId { get; set; }
} 