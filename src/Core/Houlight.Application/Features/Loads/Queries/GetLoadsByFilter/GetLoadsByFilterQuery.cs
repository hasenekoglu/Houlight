using Houlight.Domain.Enums;
using MediatR;

namespace Houlight.Application.Features.Loads.Queries.GetLoadsByFilter;

public class GetLoadsByFilterQuery : IRequest<List<GetLoadsByFilterResponse>>
{
    public string? FromLocation { get; set; }
    public string? ToLocation { get; set; }
    public LoadType? LoadType { get; set; }
    public int? MinWeight { get; set; }
    public int? MaxWeight { get; set; }
    public int? MinVolume { get; set; }
    public int? MaxVolume { get; set; }
    public DateTime? MinDeliveryDate { get; set; }
    public DateTime? MaxDeliveryDate { get; set; }
    public LoadStatus? Status { get; set; }
    public decimal? MinCustomerExpectedPrice { get; set; }
    public decimal? MaxCustomerExpectedPrice { get; set; }
    public decimal? MinCompanyOfferedPrice { get; set; }
    public decimal? MaxCompanyOfferedPrice { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? LogisticsCompanyId { get; set; }
    public Guid? AssignedVehicleId { get; set; }
    public Guid? AssignedDriverId { get; set; }
} 