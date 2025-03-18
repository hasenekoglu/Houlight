using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.VehicleTypes.Commands.CreateVehicleType;

public class CreateVehicleTypeCommandHandler : IRequestHandler<CreateVehicleTypeCommand, CreateVehicleTypeResponse>
{
    private readonly IVehicleTypeRepository _vehicleTypeRepository;
    private readonly IMapper _mapper;

    public CreateVehicleTypeCommandHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
    {
        _vehicleTypeRepository = vehicleTypeRepository;
        _mapper = mapper;
    }

    public async Task<CreateVehicleTypeResponse> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        var vehicleType = new VehicleTypeEntity
        {
            Type = request.Type,
            Description = request.Description,
            CreateDate = DateTime.UtcNow
        };

        await _vehicleTypeRepository.AddAsync(vehicleType);
        return _mapper.Map<CreateVehicleTypeResponse>(vehicleType);
    }
} 