using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Drivers.Commands.UpdateDriver;

public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, UpdateDriverResponse>
{
    private readonly IDriverRepository _driverRepository;
    private readonly IMapper _mapper;

    public UpdateDriverCommandHandler(IDriverRepository driverRepository, IMapper mapper)
    {
        _driverRepository = driverRepository;
        _mapper = mapper;
    }

    public async Task<UpdateDriverResponse> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await _driverRepository.GetByIdAsync(request.Id);
        if (driver == null)
            throw new Exception("Sürücü bulunamadı.");

        driver.Name = request.Name;
        driver.Surname = request.Surname;
        driver.PhoneNumber = request.PhoneNumber;
        driver.Email = request.Email;
        driver.LicenseNumber = request.LicenseNumber;
        //driver.LicenseType = request.LicenseType;
        //driver.LicenseExpiryDate = request.LicenseExpiryDate;
        driver.UpdateDate = DateTime.UtcNow;

        await _driverRepository.UpdateAsync(driver);
        return _mapper.Map<UpdateDriverResponse>(driver);
    }
} 