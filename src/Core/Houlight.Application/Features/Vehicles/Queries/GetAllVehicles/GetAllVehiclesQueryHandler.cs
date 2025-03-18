using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Application.Features.Vehicles.Queries.GetAllVehicles;

public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, List<GetAllVehiclesResponse>>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;

    public GetAllVehiclesQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllVehiclesResponse>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _vehicleRepository.GetAll();
        return _mapper.Map<List<GetAllVehiclesResponse>>(vehicles);
    }
} 