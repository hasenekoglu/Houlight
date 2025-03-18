using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.VehicleTypes.Commands.DeleteVehicleType;

public class DeleteVehicleTypeCommandHandler : IRequestHandler<DeleteVehicleTypeCommand, bool>
{
    private readonly IVehicleTypeRepository _vehicleTypeRepository;

    public DeleteVehicleTypeCommandHandler(IVehicleTypeRepository vehicleTypeRepository)
    {
        _vehicleTypeRepository = vehicleTypeRepository;
    }

    public async Task<bool> Handle(DeleteVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        var vehicleType = await _vehicleTypeRepository.GetByIdAsync(request.Id);
        if (vehicleType == null)
            return false;

        await _vehicleTypeRepository.DeleteAsync(vehicleType);
        return true;
    }
} 