using MediatR;

namespace Houlight.Application.Features.VehicleTypes.Commands.DeleteVehicleType;

public class DeleteVehicleTypeCommand : IRequest<bool>
{
    public Guid Id { get; set; }
} 