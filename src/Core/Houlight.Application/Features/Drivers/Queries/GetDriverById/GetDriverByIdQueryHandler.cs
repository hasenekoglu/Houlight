using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        driver = await _driverRepository.AsQueryable()
            .Include(x => x.LogisticsCompanyEntity)
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (driver == null)
            return null;

        return _mapper.Map<GetDriverByIdResponse>(driver);
    }
} 