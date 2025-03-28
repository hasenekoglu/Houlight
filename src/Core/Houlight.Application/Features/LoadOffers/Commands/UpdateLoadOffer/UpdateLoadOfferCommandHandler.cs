using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using Houlight.Domain.Enums;
using MediatR;

namespace Houlight.Application.Features.LoadOffers.Commands.UpdateLoadOffer;

public class UpdateLoadOfferCommandHandler : IRequestHandler<UpdateLoadOfferCommand, UpdateLoadOfferResponse>
{
    private readonly ILoadOfferRepository _loadOfferRepository;
    private readonly ILoadRepository _loadRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IDriverRepository _driverRepository;

    public UpdateLoadOfferCommandHandler(
        ILoadOfferRepository loadOfferRepository,
        ILoadRepository loadRepository,
        IVehicleRepository vehicleRepository,
        IDriverRepository driverRepository)
    {
        _loadOfferRepository = loadOfferRepository;
        _loadRepository = loadRepository;
        _vehicleRepository = vehicleRepository;
        _driverRepository = driverRepository;
    }

    public async Task<UpdateLoadOfferResponse> Handle(UpdateLoadOfferCommand request, CancellationToken cancellationToken)
    {
        var loadOffer = await _loadOfferRepository.GetByIdAsync(request.Id);
        if (loadOffer == null)
            throw new Exception("Teklif bulunamadı");

        var load = await _loadRepository.GetByIdAsync(loadOffer.LoadId);
        if (load == null)
            throw new Exception("Yük bulunamadı");

        if (load.Status != LoadStatus.Pending)
            throw new Exception("Sadece bekleyen yükler için teklif güncellenebilir");

        if (request.AssignedVehicleId.HasValue)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.AssignedVehicleId.Value);
            if (vehicle == null)
                throw new Exception("Araç bulunamadı");
            if (vehicle.LogisticsCompanyId != loadOffer.LogisticsCompanyId)
                throw new Exception("Araç bu lojistik şirkete ait değil");
        }

        if (request.AssignedDriverId.HasValue)
        {
            var driver = await _driverRepository.GetByIdAsync(request.AssignedDriverId.Value);
            if (driver == null)
                throw new Exception("Şoför bulunamadı");
            if (driver.LogisticsCompanyId != loadOffer.LogisticsCompanyId)
                throw new Exception("Şoför bu lojistik şirkete ait değil");
        }

        loadOffer.CompanyOfferedPrice = request.CompanyOfferedPrice;
        loadOffer.AssignedVehicleId = request.AssignedVehicleId;
        loadOffer.AssignedDriverId = request.AssignedDriverId;

        await _loadOfferRepository.UpdateAsync(loadOffer);
        return new UpdateLoadOfferResponse { Success = true };
    }
} 