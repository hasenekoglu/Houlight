using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Application.Features.Loads.Queries.GetLoadsByFilter;

public class GetLoadsByFilterQueryHandler : IRequestHandler<GetLoadsByFilterQuery, List<GetLoadsByFilterResponse>>
{
    private readonly ILoadRepository _loadRepository;
    private readonly IMapper _mapper;

    public GetLoadsByFilterQueryHandler(
        ILoadRepository loadRepository,
        IMapper mapper)
    {
        _loadRepository = loadRepository;
        _mapper = mapper;
    }

    public async Task<List<GetLoadsByFilterResponse>> Handle(GetLoadsByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = _loadRepository.AsQueryable();

        if (!string.IsNullOrEmpty(request.FromLocation))
            query = query.Where(x => x.FromLocation.Contains(request.FromLocation));

        if (!string.IsNullOrEmpty(request.ToLocation))
            query = query.Where(x => x.ToLocation.Contains(request.ToLocation));

        if (request.LoadType.HasValue)
            query = query.Where(x => x.LoadType == request.LoadType.Value);

        if (request.MinWeight.HasValue)
            query = query.Where(x => x.Weight >= request.MinWeight.Value);

        if (request.MaxWeight.HasValue)
            query = query.Where(x => x.Weight <= request.MaxWeight.Value);

        if (request.MinVolume.HasValue)
            query = query.Where(x => x.Volume >= request.MinVolume.Value);

        if (request.MaxVolume.HasValue)
            query = query.Where(x => x.Volume <= request.MaxVolume.Value);

        if (request.MinDeliveryDate.HasValue)
            query = query.Where(x => x.DeliveryDate >= request.MinDeliveryDate.Value);

        if (request.MaxDeliveryDate.HasValue)
            query = query.Where(x => x.DeliveryDate <= request.MaxDeliveryDate.Value);

        if (request.Status.HasValue)
            query = query.Where(x => x.Status == request.Status.Value);

        if (request.MinCustomerExpectedPrice.HasValue)
            query = query.Where(x => x.CustomerExpectedPrice >= request.MinCustomerExpectedPrice.Value);

        if (request.MaxCustomerExpectedPrice.HasValue)
            query = query.Where(x => x.CustomerExpectedPrice <= request.MaxCustomerExpectedPrice.Value);

        if (request.MinCompanyOfferedPrice.HasValue)
            query = query.Where(x => x.CompanyOfferedPrice >= request.MinCompanyOfferedPrice.Value);

        if (request.MaxCompanyOfferedPrice.HasValue)
            query = query.Where(x => x.CompanyOfferedPrice <= request.MaxCompanyOfferedPrice.Value);

        if (request.CustomerId.HasValue)
            query = query.Where(x => x.CustomerId == request.CustomerId.Value);

        if (request.LogisticsCompanyId.HasValue)
            query = query.Where(x => x.LogisticsCompanyId == request.LogisticsCompanyId.Value);

        if (request.AssignedVehicleId.HasValue)
            query = query.Where(x => x.AssignedVehicleId == request.AssignedVehicleId.Value);

        if (request.AssignedDriverId.HasValue)
            query = query.Where(x => x.AssignedDriverId == request.AssignedDriverId.Value);

        var loads = await query
            .Include(x => x.CustomerEntity)
            .Include(x => x.LogisticsCompanyEntity)
            .Include(x => x.VehicleEntity)
            .Include(x => x.DriverEntity)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetLoadsByFilterResponse>>(loads);
        return response;
    }
} 