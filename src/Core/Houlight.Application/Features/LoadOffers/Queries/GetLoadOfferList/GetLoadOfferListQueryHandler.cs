using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Application.Features.LoadOffers.Queries.GetLoadOfferList;

public class GetLoadOfferListQueryHandler : IRequestHandler<GetLoadOfferListQuery, List<LoadOfferListDto>>
{
    private readonly ILoadOfferRepository _loadOfferRepository;
    private readonly IMapper _mapper;

    public GetLoadOfferListQueryHandler(
        ILoadOfferRepository loadOfferRepository,
        IMapper mapper)
    {
        _loadOfferRepository = loadOfferRepository;
        _mapper = mapper;
    }

    public async Task<List<LoadOfferListDto>> Handle(GetLoadOfferListQuery request, CancellationToken cancellationToken)
    {
        var query = _loadOfferRepository.AsQueryable()
            .Include(x => x.LoadEntity)
            .Include(x => x.CustomerEntity)
            .Include(x => x.LogisticsCompanyEntity)
            .Include(x => x.VehicleEntity)
            .Include(x => x.DriverEntity)
            .AsQueryable();

        if (request.LoadId.HasValue)
            query = query.Where(x => x.LoadId == request.LoadId);

        if (request.CustomerId.HasValue)
            query = query.Where(x => x.CustomerId == request.CustomerId);

        if (request.LogisticsCompanyId.HasValue)
            query = query.Where(x => x.LogisticsCompanyId == request.LogisticsCompanyId);

        var loadOffers = await query.ToListAsync(cancellationToken);
        return _mapper.Map<List<LoadOfferListDto>>(loadOffers);
    }
}
