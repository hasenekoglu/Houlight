using MediatR;

namespace Houlight.Application.Features.VehicleTypes.Commands.UpdateVehicleType;

public class UpdateVehicleTypeCommand : IRequest<UpdateVehicleTypeResponse>
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
}

public class UpdateVehicleTypeResponse
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime UpdateDate { get; set; }
} 