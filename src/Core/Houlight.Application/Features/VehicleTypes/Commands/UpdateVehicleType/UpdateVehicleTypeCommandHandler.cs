using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.VehicleTypes.Commands.UpdateVehicleType;

public class UpdateVehicleTypeCommandHandler : IRequestHandler<UpdateVehicleTypeCommand, UpdateVehicleTypeResponse>
{
    private readonly IVehicleTypeRepository _vehicleTypeRepository;
    private readonly IMapper _mapper;

    public UpdateVehicleTypeCommandHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
    {
        _vehicleTypeRepository = vehicleTypeRepository;
        _mapper = mapper;
    }

    public async Task<UpdateVehicleTypeResponse> Handle(UpdateVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        var vehicleType = await _vehicleTypeRepository.GetByIdAsync(request.Id);
        if (vehicleType == null)
            throw new Exception("Araç tipi bulunamadı.");

        vehicleType.Type = request.Type;
        vehicleType.Description = request.Description;
        vehicleType.UpdateDate = DateTime.UtcNow;

        await _vehicleTypeRepository.UpdateAsync(vehicleType);
        return _mapper.Map<UpdateVehicleTypeResponse>(vehicleType);
    }
} 