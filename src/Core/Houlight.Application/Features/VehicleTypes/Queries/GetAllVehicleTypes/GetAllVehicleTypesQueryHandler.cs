using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.VehicleTypes.Queries.GetAllVehicleTypes;

public class GetAllVehicleTypesQueryHandler : IRequestHandler<GetAllVehicleTypesQuery, List<GetAllVehicleTypesResponse>>
{
    private readonly IVehicleTypeRepository _vehicleTypeRepository;
    private readonly IMapper _mapper;

    public GetAllVehicleTypesQueryHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
    {
        _vehicleTypeRepository = vehicleTypeRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllVehicleTypesResponse>> Handle(GetAllVehicleTypesQuery request, CancellationToken cancellationToken)
    {
        var vehicleTypes = await _vehicleTypeRepository.GetAll();
        return _mapper.Map<List<GetAllVehicleTypesResponse>>(vehicleTypes);
    }
} 