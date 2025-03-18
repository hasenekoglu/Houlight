using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Vehicles.Commands.CreateVehicle;

public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, CreateVehicleResponse>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;

    public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<CreateVehicleResponse> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = new VehicleEntity
        {
            PlateNumber = request.PlateNumber,
            Capacity = request.Capacity,
            IsAvailable = request.IsAvailable,
            CurrentWeight = request.CurrentWeight,
            CurrentVolume = request.CurrentVolume,
            LogisticsCompanyId = request.LogisticsCompanyId,
            AssignedDriverId = request.AssignedDriverId
        };

        await _vehicleRepository.AddAsync(vehicle);
     

        return _mapper.Map<CreateVehicleResponse>(vehicle);
    }
} 