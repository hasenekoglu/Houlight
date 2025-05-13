using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using Houlight.Domain.Enums;
using MediatR;

namespace Houlight.Application.Features.LoadOffers.Commands.CreateLoadOffer;

public class CreateLoadOfferCommandHandler : IRequestHandler<CreateLoadOfferCommand, CreateLoadOfferResponse>
{
    private readonly ILoadOfferRepository _loadOfferRepository;
    private readonly ILoadRepository _loadRepository;
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IDriverRepository _driverRepository;

    public CreateLoadOfferCommandHandler(
        ILoadOfferRepository loadOfferRepository,
        ILoadRepository loadRepository,
        ILogisticsCompanyRepository logisticsCompanyRepository,
        IVehicleRepository vehicleRepository,
        IDriverRepository driverRepository)
    {
        _loadOfferRepository = loadOfferRepository;
        _loadRepository = loadRepository;
        _logisticsCompanyRepository = logisticsCompanyRepository;
        _vehicleRepository = vehicleRepository;
        _driverRepository = driverRepository;
    }

    public async Task<CreateLoadOfferResponse> Handle(CreateLoadOfferCommand request, CancellationToken cancellationToken)
    {
        var load = await _loadRepository.GetByIdAsync(request.LoadId);
        if (load == null)
            throw new Exception("Yük bulunamadı");

        if (load.Status != LoadStatus.Pending)
            throw new Exception("Sadece bekleyen yükler için teklif verilebilir");

        // Aynı şirkete aynı yük için daha önce teklif verilmiş mi kontrol et
        var existingOffer = await _loadOfferRepository.FirstOrDefaultAsync(x => x.LoadId == request.LoadId && x.LogisticsCompanyId == request.LogisticsCompanyId);
        if (existingOffer != null)
            throw new Exception("Bu yüke zaten bir teklif verdiniz.");

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

        var loadOffer = new LoadOfferEntity
        {
            LoadId = load.Id,
            FromLocation = load.FromLocation,
            ToLocation = load.ToLocation,
            LoadType = load.LoadType,
            Weight = load.Weight,
            Volume = load.Volume,
            Description = load.Description,
            DeliveryDate = load.DeliveryDate,
            CustomerExpectedPrice = load.CustomerExpectedPrice,
            CompanyOfferedPrice = request.CompanyOfferedPrice,
            CustomerId = load.CustomerId,
            LogisticsCompanyId = request.LogisticsCompanyId,
            AssignedVehicleId = request.AssignedVehicleId,
            AssignedDriverId = request.AssignedDriverId
        };

        await _loadOfferRepository.AddAsync(loadOffer);
        return new CreateLoadOfferResponse { Id = loadOffer.Id };
    }
} 