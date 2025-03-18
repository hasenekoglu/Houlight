using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;
using System.Linq;

namespace Houlight.Application.Features.VehicleTypes.Queries.GetVehicleTypesByFilter;

public class GetVehicleTypesByFilterQueryHandler : IRequestHandler<GetVehicleTypesByFilterQuery, List<GetVehicleTypesByFilterResponse>>
{
    private readonly IVehicleTypeRepository _vehicleTypeRepository;
    private readonly IMapper _mapper;

    public GetVehicleTypesByFilterQueryHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
    {
        _vehicleTypeRepository = vehicleTypeRepository;
        _mapper = mapper;
    }

    public async Task<List<GetVehicleTypesByFilterResponse>> Handle(GetVehicleTypesByFilterQuery request, CancellationToken cancellationToken)
    {
        var vehicleTypes = await _vehicleTypeRepository.GetAll();
        
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            vehicleTypes = vehicleTypes.Where(x => 
                x.Type.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                x.Description.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        if (!string.IsNullOrEmpty(request.Type))
        {
            vehicleTypes = vehicleTypes.Where(x => 
                x.Type.Contains(request.Type, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        return _mapper.Map<List<GetVehicleTypesByFilterResponse>>(vehicleTypes);
    }
} 