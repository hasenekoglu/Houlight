using MediatR;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using Houlight.Domain.Enums;

namespace Houlight.Application.Features.LoadOffers.Commands.DeleteLoadOffer;

public class DeleteLoadOfferCommandHandler : IRequestHandler<DeleteLoadOfferCommand, DeleteLoadOfferResponse>
{
    private readonly ILoadOfferRepository _loadOfferRepository;
    private readonly ILoadRepository _loadRepository;

    public DeleteLoadOfferCommandHandler(ILoadOfferRepository loadOfferRepository, ILoadRepository loadRepository)
    {
        _loadOfferRepository = loadOfferRepository;
        _loadRepository = loadRepository;
    }

    public async Task<DeleteLoadOfferResponse> Handle(DeleteLoadOfferCommand request, CancellationToken cancellationToken)
    {
        var loadOffer = await _loadOfferRepository.GetByIdAsync(request.Id);
        if (loadOffer == null)
        {
            return new DeleteLoadOfferResponse
            {
                Success = false,
                Message = "Teklif bulunamadı."
            };
        }

        var load = await _loadRepository.GetByIdAsync(loadOffer.LoadId);
        if (load == null)
        {
            return new DeleteLoadOfferResponse
            {
                Success = false,
                Message = "Yük bulunamadı."
            };
        }

        if (load.Status != LoadStatus.Pending)
        {
            return new DeleteLoadOfferResponse
            {
                Success = false,
                Message = "Sadece bekleyen yükler için teklif silinebilir."
            };
        }

        await _loadOfferRepository.DeleteAsync(loadOffer);

        return new DeleteLoadOfferResponse
        {
            Success = true,
            Message = "Teklif başarıyla silindi."
        };
    }
} 