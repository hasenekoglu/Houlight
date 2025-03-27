using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Loads.Commands.CustomerLoadUpdate;

public class CustomerLoadUpdateCommandHandler : IRequestHandler<CustomerLoadUpdateCommand, CustomerLoadUpdateResponse>
{
    private readonly ILoadRepository _loadRepository;
    private readonly IMapper _mapper;

    public CustomerLoadUpdateCommandHandler(
        ILoadRepository loadRepository,
        IMapper mapper)
    {
        _loadRepository = loadRepository;
        _mapper = mapper;
    }

    public async Task<CustomerLoadUpdateResponse> Handle(CustomerLoadUpdateCommand request, CancellationToken cancellationToken)
    {
        var load = await _loadRepository.GetByIdAsync(request.Id);
        if (load == null)
            throw new Exception("Yük bulunamadı");

        if (load.Status != Domain.Enums.LoadStatus.Pending)
            throw new Exception("Sadece bekleyen yükler güncellenebilir");

        _mapper.Map(request, load);
        await _loadRepository.UpdateAsync(load);

        var response = _mapper.Map<CustomerLoadUpdateResponse>(load);
        return response;
    }
} 