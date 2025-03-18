using MediatR;

namespace Houlight.Application.Features.VehicleTypes.Commands.CreateVehicleType;

public class CreateVehicleTypeCommand : IRequest<CreateVehicleTypeResponse>
{
    public string Type { get; set; }
    public string Description { get; set; }
}

public class CreateVehicleTypeResponse
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
} 