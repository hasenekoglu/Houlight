using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Application.Features.Vehicles.Queries.GetVehiclesByFilter;

public class GetVehiclesByFilterQueryHandler : IRequestHandler<GetVehiclesByFilterQuery, List<GetVehiclesByFilterResponse>>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;

    public GetVehiclesByFilterQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<List<GetVehiclesByFilterResponse>> Handle(GetVehiclesByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = _vehicleRepository.AsQueryable();

        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(x => 
                x.PlateNumber.ToLower().Contains(searchTerm) || 
                x.LogisticsCompanyEntity.CompanyName.ToLower().Contains(searchTerm));
        }

        if (!string.IsNullOrEmpty(request.PlateNumber))
        {
            query = query.Where(x => x.PlateNumber.Contains(request.PlateNumber));
        }

        if (request.IsAvailable.HasValue)
        {
            query = query.Where(x => x.IsAvailable == request.IsAvailable.Value);
        }

        if (request.LogisticsCompanyId.HasValue)
        {
            query = query.Where(x => x.LogisticsCompanyId == request.LogisticsCompanyId.Value);
        }

        if (request.AssignedDriverId.HasValue)
        {
            query = query.Where(x => x.AssignedDriverId == request.AssignedDriverId.Value);
        }

        if (request.MinCapacity.HasValue)
        {
            query = query.Where(x => x.Capacity >= request.MinCapacity.Value);
        }

        if (request.MaxCapacity.HasValue)
        {
            query = query.Where(x => x.Capacity <= request.MaxCapacity.Value);
        }

        var vehicles = await query
            .Include(x => x.LogisticsCompanyEntity)
            .Include(x => x.AssignedDriver)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<GetVehiclesByFilterResponse>>(vehicles);
    }
} 