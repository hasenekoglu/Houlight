using AutoMapper;
using Houlight.Application.Features.Drivers.Commands.CreateDriver;
using Houlight.Application.Features.Drivers.Commands.UpdateDriver;
using Houlight.Application.Features.Drivers.Queries.GetAllDrivers;
using Houlight.Application.Features.Drivers.Queries.GetDriverById;
using Houlight.Application.Features.Drivers.Queries.GetDriversByFilter;
using Houlight.Domain.Entities;

namespace Houlight.Application.Mapping;

public class DriverMappingProfile : Profile
{
    public DriverMappingProfile()
    {
        CreateMap<DriverEntity, CreateDriverResponse>()
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName));
        CreateMap<DriverEntity, UpdateDriverResponse>();
        CreateMap<DriverEntity, GetAllDriversResponse>()
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName));
        CreateMap<DriverEntity, GetDriverByIdResponse>()
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName));
        CreateMap<DriverEntity, GetDriversByFilterResponse>()
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName));
    }
} 