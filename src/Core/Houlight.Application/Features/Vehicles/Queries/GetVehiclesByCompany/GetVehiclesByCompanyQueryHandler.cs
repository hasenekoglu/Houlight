using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Application.Features.Vehicles.Queries.GetVehiclesByCompany;

public class GetVehiclesByCompanyQueryHandler : IRequestHandler<GetVehiclesByCompanyQuery, List<GetVehiclesByCompanyResponse>>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;

    public GetVehiclesByCompanyQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<List<GetVehiclesByCompanyResponse>> Handle(GetVehiclesByCompanyQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _vehicleRepository.AsQueryable()
            .Include(v => v.VehicleTypeEntity)
            .Include(v => v.AssignedDriver)
            .Where(v => v.LogisticsCompanyId == request.CompanyId)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<GetVehiclesByCompanyResponse>>(vehicles);
    }
} 