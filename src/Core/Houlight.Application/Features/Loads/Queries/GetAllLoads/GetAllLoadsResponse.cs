using Houlight.Domain.Enums;

namespace Houlight.Application.Features.Loads.Queries.GetAllLoads;

public class GetAllLoadsResponse
{
    public Guid Id { get; set; }
    public string FromLocation { get; set; }
    public string ToLocation { get; set; }
    public LoadType LoadType { get; set; }
    public int Weight { get; set; }
    public int Volume { get; set; }
    public string? Description { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public LoadStatus Status { get; set; }
    public decimal? CustomerExpectedPrice { get; set; }
    public decimal? CompanyOfferedPrice { get; set; }
    public string CustomerName { get; set; }
    public string? LogisticsCompanyName { get; set; }
    public string? AssignedVehiclePlate { get; set; }
    public string? AssignedDriverName { get; set; }
} 