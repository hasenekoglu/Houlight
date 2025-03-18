 using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.VehicleTypes.Queries.GetVehicleTypeById;

public class GetVehicleTypeByIdQueryHandler : IRequestHandler<GetVehicleTypeByIdQuery, GetVehicleTypeByIdResponse>
{
    private readonly IVehicleTypeRepository _vehicleTypeRepository;
    private readonly IMapper _mapper;

    public GetVehicleTypeByIdQueryHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
    {
        _vehicleTypeRepository = vehicleTypeRepository;
        _mapper = mapper;
    }

    public async Task<GetVehicleTypeByIdResponse> Handle(GetVehicleTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicleType = await _vehicleTypeRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetVehicleTypeByIdResponse>(vehicleType);
    }
}