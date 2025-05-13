using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Enums;
using MediatR;

namespace Houlight.Application.Features.Loads.Commands.LogisticsCompanyLoadUpdate;

public class LogisticsCompanyLoadUpdateCommandHandler : IRequestHandler<LogisticsCompanyLoadUpdateCommand, LogisticsCompanyLoadUpdateResponse>
{
    private readonly ILoadRepository _loadRepository;
    private readonly IMapper _mapper;

    public LogisticsCompanyLoadUpdateCommandHandler(ILoadRepository loadRepository, IMapper mapper)
    {
        _loadRepository = loadRepository;
        _mapper = mapper;
    }

    public async Task<LogisticsCompanyLoadUpdateResponse> Handle(LogisticsCompanyLoadUpdateCommand request, CancellationToken cancellationToken)
    {
        var load = await _loadRepository.GetByIdAsync(request.Id);
        if (load == null)
            throw new Exception("Yük bulunamadı");

        // Gerekirse şirket yetkisi kontrolü eklenebilir

        load.Status = request.Status;
        await _loadRepository.UpdateAsync(load);

        return _mapper.Map<LogisticsCompanyLoadUpdateResponse>(load);
    }
} 