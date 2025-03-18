using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;
using System.Linq;

namespace Houlight.Application.Features.Drivers.Queries.GetDriversByFilter;

public class GetDriversByFilterQueryHandler : IRequestHandler<GetDriversByFilterQuery, List<GetDriversByFilterResponse>>
{
    private readonly IDriverRepository _driverRepository;
    private readonly IMapper _mapper;

    public GetDriversByFilterQueryHandler(IDriverRepository driverRepository, IMapper mapper)
    {
        _driverRepository = driverRepository;
        _mapper = mapper;
    }

    public async Task<List<GetDriversByFilterResponse>> Handle(GetDriversByFilterQuery request, CancellationToken cancellationToken)
    {
        var drivers = await _driverRepository.GetAll();
        
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            drivers = drivers.Where(x => 
                x.Name.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                x.Surname.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                x.Email.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                x.PhoneNumber.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        //if (!string.IsNullOrEmpty(request.LicenseType))
        //{
        //    drivers = drivers.Where(x => 
        //        x.LicenseType.Contains(request.LicenseType, StringComparison.OrdinalIgnoreCase)
        //    ).ToList();
        //}

        //if (request.LicenseExpiryDate.HasValue)
        //{
        //    drivers = drivers.Where(x => 
        //        x.LicenseExpiryDate <= request.LicenseExpiryDate.Value
        //    ).ToList();
        //}

        return _mapper.Map<List<GetDriversByFilterResponse>>(drivers);
    }
} 