using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Loads.Commands.LogisticsCompanyLoadUpdate;

public class LogisticsCompanyLoadUpdateCommandHandler : IRequestHandler<LogisticsCompanyLoadUpdateCommand, LogisticsCompanyLoadUpdateResponse>
{
    private readonly ILoadRepository _loadRepository;
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IMapper _mapper;

    public LogisticsCompanyLoadUpdateCommandHandler(
        ILoadRepository loadRepository,
        ILogisticsCompanyRepository logisticsCompanyRepository,
        IVehicleRepository vehicleRepository,
        IDriverRepository driverRepository,
        IMapper mapper)
    {
        _loadRepository = loadRepository;
        _logisticsCompanyRepository = logisticsCompanyRepository;
        _vehicleRepository = vehicleRepository;
        _driverRepository = driverRepository;
        _mapper = mapper;
    }

    public async Task<LogisticsCompanyLoadUpdateResponse> Handle(LogisticsCompanyLoadUpdateCommand request, CancellationToken cancellationToken)
    {
        var load = await _loadRepository.GetByIdAsync(request.Id);
        if (load == null)
            throw new Exception("Yük bulunamadı");

        if (load.Status != Domain.Enums.LoadStatus.Pending)
            throw new Exception("Sadece bekleyen yükler için teklif verilebilir");

        var logisticsCompany = await _logisticsCompanyRepository.GetByIdAsync(request.LogisticsCompanyId);
        if (logisticsCompany == null)
            throw new Exception("Lojistik şirket bulunamadı");

        if (request.AssignedVehicleId.HasValue)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.AssignedVehicleId.Value);
            if (vehicle == null)
                throw new Exception("Araç bulunamadı");
            if (vehicle.LogisticsCompanyId != request.LogisticsCompanyId)
                throw new Exception("Araç bu lojistik şirkete ait değil");
        }

        if (request.AssignedDriverId.HasValue)
        {
            var driver = await _driverRepository.GetByIdAsync(request.AssignedDriverId.Value);
            if (driver == null)
                throw new Exception("Şoför bulunamadı");
            if (driver.LogisticsCompanyId != request.LogisticsCompanyId)
                throw new Exception("Şoför bu lojistik şirkete ait değil");
        }

        load.CompanyOfferedPrice = request.CompanyOfferedPrice;
        load.LogisticsCompanyId = request.LogisticsCompanyId;
        load.AssignedVehicleId = request.AssignedVehicleId;
        load.AssignedDriverId = request.AssignedDriverId;
        load.Status = Domain.Enums.LoadStatus.Assigned;

        await _loadRepository.UpdateAsync(load);

        var response = _mapper.Map<LogisticsCompanyLoadUpdateResponse>(load);
        return response;
    }
} 