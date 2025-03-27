using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Vehicles.Commands.UpdateVehicle;

public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, UpdateVehicleResponse>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;
   private readonly IDriverRepository _driverRepository;
    private readonly IVehicleTypeRepository _vehicleTypeRepository;
    private readonly IMapper _mapper;

    public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository, IMapper mapper, ILogisticsCompanyRepository logisticsCompanyRepository, IDriverRepository driverRepository, IVehicleTypeRepository vehicleTypeRepository)
    {
        _vehicleRepository = vehicleRepository;
        _logisticsCompanyRepository=logisticsCompanyRepository;
        _driverRepository=driverRepository;
        _vehicleTypeRepository=vehicleTypeRepository;
        _mapper = mapper;
    }

    public async Task<UpdateVehicleResponse> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(request.Id);
        if (vehicle == null)
            throw new Exception("Araç bulunamadı.");
        // Lojistik şirketi kontrolü
        var logisticsCompany = await _logisticsCompanyRepository.GetByIdAsync(request.LogisticsCompanyId);
        if (logisticsCompany == null)
            throw new Exception("Belirtilen lojistik şirketi bulunamadı.");

        // Sürücü kontrolü (eğer atanmışsa)
        var assignedDriver = await _driverRepository.GetByIdAsync(request.AssignedDriverId.Value);
        if (assignedDriver == null)
        {
            var driver = await _driverRepository.GetByIdAsync(request.AssignedDriverId.Value);
            if (driver == null)
                throw new Exception("Belirtilen sürücü bulunamadı.");
        }

       

        var vehicleTypeId = await _vehicleTypeRepository.GetByIdAsync(request.VehicleTypeId);
        if (vehicleTypeId == null)
            throw new Exception($"ID'si {vehicleTypeId} olan araç tipi bulunamadı.");


        vehicle.PlateNumber = request.PlateNumber;
        vehicle.Capacity = request.Capacity;
        vehicle.IsAvailable = request.IsAvailable;
        vehicle.CurrentWeight = request.CurrentWeight;
        vehicle.CurrentVolume = request.CurrentVolume;
        vehicle.LogisticsCompanyId = request.LogisticsCompanyId;
        vehicle.AssignedDriverId = request.AssignedDriverId;
        vehicle.VehicleTypeId = request.VehicleTypeId;
        vehicle.UpdateDate = DateTime.UtcNow;

        await _vehicleRepository.UpdateAsync(vehicle);
      

        var response = _mapper.Map<UpdateVehicleResponse>(vehicle);
        response.UpdateDate = DateTime.UtcNow;
        response.LogisticsCompanyName = logisticsCompany.CompanyName;
        response.AssignedDriverName = $"{assignedDriver.Name} {assignedDriver.Surname}";
        response.VehicleTypeType = vehicleTypeId.Type;
        return response;

    }
} 