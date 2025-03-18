using MediatR;

namespace Houlight.Application.Features.Vehicles.Queries.GetAllVehicles;

public class GetAllVehiclesQuery : IRequest<List<GetAllVehiclesResponse>>
{
}

public class GetAllVehiclesResponse
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
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
} 