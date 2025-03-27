using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Application.Features.Loads.Queries.GetLoadById;

public class GetLoadByIdQueryHandler : IRequestHandler<GetLoadByIdQuery, GetLoadByIdResponse>
{
    private readonly ILoadRepository _loadRepository;
    private readonly IMapper _mapper;

    public GetLoadByIdQueryHandler(ILoadRepository loadRepository, IMapper mapper)
    {
        _loadRepository=loadRepository;
        _mapper=mapper;
    }


    public async Task<GetLoadByIdResponse> Handle(GetLoadByIdQuery request, CancellationToken cancellationToken)
    {
        var load = await _loadRepository.AsQueryable()
            .Include(x => x.CustomerEntity)
            .Include(x => x.LogisticsCompanyEntity)
            .Include(x => x.VehicleEntity)
            .Include(x => x.DriverEntity)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (load == null)
            throw new Exception("Yük bulunamadı");

        var response = _mapper.Map<GetLoadByIdResponse>(load);
        return response;
    }
} 