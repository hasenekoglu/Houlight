using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.Drivers.Queries.GetAllDrivers;

public class GetAllDriversQueryHandler : IRequestHandler<GetAllDriversQuery, List<GetAllDriversResponse>>
{
    private readonly IDriverRepository _driverRepository;
    private readonly IMapper _mapper;

    public GetAllDriversQueryHandler(IDriverRepository driverRepository, IMapper mapper)
    {
        _driverRepository = driverRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllDriversResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
    {
        var drivers = await _driverRepository.GetList(
            predicate: null,
            noTracking: true,
            orderBy: null,
            v=>v.LogisticsCompanyEntity);
        return _mapper.Map<List<GetAllDriversResponse>>(drivers);
    }
} 