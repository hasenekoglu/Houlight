using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Vehicles.Commands.UpdateVehicle;

public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, UpdateVehicleResponse>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;

    public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<UpdateVehicleResponse> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(request.Id);
        if (vehicle == null)
            throw new Exception("Araç bulunamadı.");

        vehicle.PlateNumber = request.PlateNumber;
        vehicle.Capacity = request.Capacity;
        vehicle.IsAvailable = request.IsAvailable;
        vehicle.CurrentWeight = request.CurrentWeight;
        vehicle.CurrentVolume = request.CurrentVolume;
        vehicle.LogisticsCompanyId = request.LogisticsCompanyId;
        vehicle.AssignedDriverId = request.AssignedDriverId;

        await _vehicleRepository.UpdateAsync(vehicle);
      

        return _mapper.Map<UpdateVehicleResponse>(vehicle);
    }
} 