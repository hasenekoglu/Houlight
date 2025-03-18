using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Application.Features.Vehicles.Queries.GetVehicleById;

public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, GetVehicleByIdResponse>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;

    public GetVehicleByIdQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<GetVehicleByIdResponse> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(request.Id);
        if (vehicle == null)
            return null;

        return _mapper.Map<GetVehicleByIdResponse>(vehicle);
    }
} 