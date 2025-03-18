using MediatR;

namespace Houlight.Application.Features.Vehicles.Commands.DeleteVehicle;

public class DeleteVehicleCommand : IRequest<bool>
{
    public Guid Id { get; set; }
} 