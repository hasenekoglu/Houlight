using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Application.Features.Loads.Queries.GetAllLoads;

public class GetAllLoadsQueryHandler : IRequestHandler<GetAllLoadsQuery, List<GetAllLoadsResponse>>
{
    private readonly ILoadRepository _loadRepository;
    private readonly IMapper _mapper;

    public GetAllLoadsQueryHandler(
        ILoadRepository loadRepository,
        IMapper mapper)
    {
        _loadRepository = loadRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllLoadsResponse>> Handle(GetAllLoadsQuery request, CancellationToken cancellationToken)
    {
        var query = _loadRepository.AsQueryable();

        var loads = await query
            .Include(x => x.CustomerEntity)
            .Include(x => x.LogisticsCompanyEntity)
            .Include(x => x.VehicleEntity)
            .Include(x => x.DriverEntity)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllLoadsResponse>>(loads);
        return response;
    }
} 