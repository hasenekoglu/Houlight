using MediatR;

namespace Houlight.Application.Features.Vehicles.Queries.GetVehiclesByFilter;

public class GetVehiclesByFilterQuery : IRequest<List<GetVehiclesByFilterResponse>>
{
    public string? SearchTerm { get; set; }
    public string? PlateNumber { get; set; }
    public bool? IsAvailable { get; set; }
    public Guid? LogisticsCompanyId { get; set; }
    public Guid? AssignedDriverId { get; set; }
    public int? MinCapacity { get; set; }
    public int? MaxCapacity { get; set; }
}

public class GetVehiclesByFilterResponse
{
    public Guid Id { get; set; }
    public string PlateNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
    public int CurrentWeight { get; set; }
    public int CurrentVolume { get; set; }
    public Guid LogisticsCompanyId { get; set; }
    public string LogisticsCompanyName { get; set; }
    public Guid AssignedDriverId { get; set; }
    public string AssignedDriverName { get; set; }
    public Guid VehicleTypeId { get; set; }
    public string VehicleTypeType { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
} 