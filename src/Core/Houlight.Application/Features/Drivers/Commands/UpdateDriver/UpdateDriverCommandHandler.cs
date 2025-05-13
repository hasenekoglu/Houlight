using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Drivers.Commands.UpdateDriver;

public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, UpdateDriverResponse>
{
    private readonly IDriverRepository _driverRepository;
    private readonly ILogisticsCompanyRepository _logisticsCompanyRepository;
    private readonly IMapper _mapper;

    public UpdateDriverCommandHandler(IDriverRepository driverRepository, IMapper mapper, ILogisticsCompanyRepository logisticsCompanyRepository)
    {
        _driverRepository = driverRepository;
        _logisticsCompanyRepository=logisticsCompanyRepository;
        _mapper = mapper;
    }

    public async Task<UpdateDriverResponse> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await _driverRepository.GetByIdAsync(request.Id);
        if (driver == null)
            throw new Exception("Sürücü bulunamadı.");
        var logisticsCompany = await _logisticsCompanyRepository.GetByIdAsync(request.LogisticsCompanyId);
        if (logisticsCompany == null)
            throw new Exception("Lojistik şirket bulunamadı.");

        driver.Name = request.Name;
        driver.Surname = request.Surname;
        driver.PhoneNumber = request.PhoneNumber;
        driver.Email = request.Email;
        driver.LicenseNumber = request.LicenseNumber;
        driver.DriverStatus = request.DriverStatus;
        //driver.LicenseType = request.LicenseType;
        //driver.LicenseExpiryDate = request.LicenseExpiryDate;
        driver.UpdateDate = DateTime.UtcNow;

        await _driverRepository.UpdateAsync(driver);
        var response = _mapper.Map<UpdateDriverResponse>(driver);
    
        return response;

    }
} 