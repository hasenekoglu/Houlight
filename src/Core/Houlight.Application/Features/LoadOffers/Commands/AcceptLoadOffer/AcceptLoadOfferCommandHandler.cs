using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using Houlight.Domain.Enums;
using MediatR;

namespace Houlight.Application.Features.LoadOffers.Commands.AcceptLoadOffer;

public class AcceptLoadOfferCommandHandler : IRequestHandler<AcceptLoadOfferCommand, AcceptLoadOfferResponse>
{
    private readonly ILoadOfferRepository _loadOfferRepository;
    private readonly ILoadRepository _loadRepository;

    public AcceptLoadOfferCommandHandler(
        ILoadOfferRepository loadOfferRepository,
        ILoadRepository loadRepository)
    {
        _loadOfferRepository = loadOfferRepository;
        _loadRepository = loadRepository;
    }

    public async Task<AcceptLoadOfferResponse> Handle(AcceptLoadOfferCommand request, CancellationToken cancellationToken)
    {
        var loadOffer = await _loadOfferRepository.GetByIdAsync(request.LoadOfferId);
        if (loadOffer == null)
            throw new Exception("Teklif bulunamadı");

        var load = await _loadRepository.GetByIdAsync(loadOffer.LoadId);
        if (load == null)
            throw new Exception("Yük bulunamadı");

        if (load.Status != LoadStatus.Pending)
            throw new Exception("Sadece bekleyen yükler için teklif kabul edilebilir");

        // Tüm teklifleri getir ve statüleri güncelle
        var allOffers = await _loadOfferRepository.GetList(x => x.LoadId == load.Id);
        foreach (var offer in allOffers)
        {
            if (offer.Id == loadOffer.Id)
                offer.OfferStatus = LoadStatus.Accepted;
            else
                offer.OfferStatus = LoadStatus.Rejected;
            await _loadOfferRepository.UpdateAsync(offer);
        }

        // Load'u güncelle
        load.LogisticsCompanyId = loadOffer.LogisticsCompanyId;
        load.AssignedVehicleId = loadOffer.AssignedVehicleId;
        load.AssignedDriverId = loadOffer.AssignedDriverId;
        load.CompanyOfferedPrice = loadOffer.CompanyOfferedPrice;
        load.Status = LoadStatus.Accepted;

        await _loadRepository.UpdateAsync(load);
        return new AcceptLoadOfferResponse { Success = true };
    }
} 