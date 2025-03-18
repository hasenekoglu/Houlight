using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.Vehicles.Commands.DeleteVehicle;

public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, bool>
{
    private readonly IVehicleRepository _vehicleRepository;

    public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<bool> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(request.Id);
        if (vehicle == null)
            throw new Exception("Arac bulunamadý.");

        await _vehicleRepository.DeleteAsync(vehicle);
    

        return true;
    }
} 