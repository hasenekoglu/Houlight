using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Loads.Commands.DeleteLoad;

public class DeleteLoadCommandHandler : IRequestHandler<DeleteLoadCommand, bool>
{
    private readonly ILoadRepository _loadRepository;

    public DeleteLoadCommandHandler(ILoadRepository loadRepository)
    {
        _loadRepository=loadRepository;
    }

   
    public async Task<bool> Handle(DeleteLoadCommand request, CancellationToken cancellationToken)
    {
        var load = await _loadRepository.GetByIdAsync(request.Id);
        if (load == null)
            throw new Exception("Yük bulunamadı");

        if (load.Status != Domain.Enums.LoadStatus.Pending)
            throw new Exception("Sadece bekleyen yükler silinebilir");

        await _loadRepository.DeleteAsync(load);
        return true;
    }
} 