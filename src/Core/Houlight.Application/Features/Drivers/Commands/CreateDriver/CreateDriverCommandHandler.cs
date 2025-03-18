using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Drivers.Commands.CreateDriver;

public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, CreateDriverResponse>
{
    private readonly IDriverRepository _driverRepository;
    private readonly IMapper _mapper;

    public CreateDriverCommandHandler(IDriverRepository driverRepository, IMapper mapper)
    {
        _driverRepository = driverRepository;
        _mapper = mapper;
    }

    public async Task<CreateDriverResponse> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = new DriverEntity
        {
            LogisticsCompanyId = request.LogisticsCompanyId,
            Name = request.Name,
            Surname = request.Surname,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            LicenseNumber = request.LicenseNumber,
            //LicenseType = request.LicenseType,
            //LicenseExpiryDate = request.LicenseExpiryDate,
            CreateDate = DateTime.UtcNow
        };

        await _driverRepository.AddAsync(driver);
        return _mapper.Map<CreateDriverResponse>(driver);
    }
} 