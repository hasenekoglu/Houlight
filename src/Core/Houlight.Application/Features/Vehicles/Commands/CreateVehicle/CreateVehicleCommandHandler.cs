using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Vehicles.Commands.CreateVehicle;

public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, CreateVehicleResponse>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IVehicleTypeRepository _vehicleTypeRepository;
    private readonly IMapper _mapper;

    public CreateVehicleCommandHandler(
        IVehicleRepository vehicleRepository,
        ILogisticsCompanyRepository logisticsCompanyRepository,
        IDriverRepository driverRepository,
        IVehicleTypeRepository vehicleTypeRepository,
        IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _logisticsCompanyRepository = logisticsCompanyRepository;
        _driverRepository = driverRepository;
        _vehicleTypeRepository = vehicleTypeRepository;
        _mapper = mapper;
    }

    public async Task<CreateVehicleResponse> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        // Lojistik şirket kontrolü
        var logisticsCompany = await _logisticsCompanyRepository.GetByIdAsync(request.LogisticsCompanyId);
        if (logisticsCompany == null)
            throw new Exception("Lojistik şirket bulunamadı.");

        // Sürücü kontrolü (eğer atanmışsa)
        if (request.AssignedDriverId.HasValue)
        {
            var driver = await _driverRepository.GetByIdAsync(request.AssignedDriverId.Value);
            if (driver == null)
                throw new Exception("Sürücü bulunamadı.");
        }

        // Araç tiplerini kontrol et ve getir
        var vehicleType = await _vehicleTypeRepository.GetByIdAsync(request.VehicleTypeId);
        if (vehicleType == null)
            throw new Exception("Araç tipi bulunamadı.");

        var vehicle = new VehicleEntity
        {
            PlateNumber = request.PlateNumber,
            Capacity = request.Capacity,
            IsAvailable = request.IsAvailable,
            CurrentWeight = request.CurrentWeight,
            CurrentVolume = request.CurrentVolume,
            LogisticsCompanyId = request.LogisticsCompanyId,
            AssignedDriverId = request.AssignedDriverId,
            VehicleTypeId = request.VehicleTypeId
        };

        await _vehicleRepository.AddAsync(vehicle);
        var response = _mapper.Map<CreateVehicleResponse>(vehicle);
        response.LogisticsCompanyName = logisticsCompany.CompanyName;
        response.VehicleTypeType = vehicleType.Type;
   
       
        return response;
    }
} 