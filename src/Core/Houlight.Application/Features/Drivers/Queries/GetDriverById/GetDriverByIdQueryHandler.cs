using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.Drivers.Queries.GetDriverById;

public class GetDriverByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, GetDriverByIdResponse>
{
    private readonly IDriverRepository _driverRepository;
    private readonly IMapper _mapper;

    public GetDriverByIdQueryHandler(IDriverRepository driverRepository, IMapper mapper)
    {
        _driverRepository = driverRepository;
        _mapper = mapper;
    }

    public async Task<GetDriverByIdResponse> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
    {
        var driver = await _driverRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetDriverByIdResponse>(driver);
    }
} 