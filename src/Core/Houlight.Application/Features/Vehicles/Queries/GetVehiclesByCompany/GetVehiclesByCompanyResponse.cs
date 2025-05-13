using Houlight.Domain.Enums;

namespace Houlight.Application.Features.Vehicles.Queries.GetVehiclesByCompany;

public class GetVehiclesByCompanyResponse
{
    public Guid Id { get; set; }
    public string Plate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string VehicleType { get; set; }
    public string VehicleTypeDescription { get; set; }
    public int Capacity { get; set; }
    public bool IsActive { get; set; }
    public string? AssignedDriverName { get; set; }
} 