using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.Drivers.Commands.DeleteDriver;

public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, bool>
{
    private readonly IDriverRepository _driverRepository;

    public DeleteDriverCommandHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<bool> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await _driverRepository.GetByIdAsync(request.Id);
        if (driver == null)
           throw new Exception("Þoför bulunamadý.");

        await _driverRepository.DeleteAsync(driver);
        return true;
    }
} 