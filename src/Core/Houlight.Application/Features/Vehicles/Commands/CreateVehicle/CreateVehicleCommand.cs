using MediatR;

namespace Houlight.Application.Features.Vehicles.Commands.CreateVehicle;

public class CreateVehicleCommand : IRequest<CreateVehicleResponse>
{
    public string PlateNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
    public int CurrentWeight { get; set; }
    public int CurrentVolume { get; set; }
    public Guid LogisticsCompanyId { get; set; }
    public Guid AssignedDriverId { get; set; }
    public List<Guid> VehicleTypeIds { get; set; }
}

public class CreateVehicleResponse
{
    public Guid Id { get; set; }
    public string PlateNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
    public int CurrentWeight { get; set; }
    public int CurrentVolume { get; set; }
    public Guid LogisticsCompanyId { get; set; }
    public Guid AssignedDriverId { get; set; }
    public DateTime CreateDate { get; set; }
} 