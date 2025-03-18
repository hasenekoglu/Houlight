using AutoMapper;
using Houlight.Application.Features.Vehicles.Commands.CreateVehicle;
using Houlight.Application.Features.Vehicles.Commands.UpdateVehicle;
using Houlight.Application.Features.Vehicles.Queries.GetAllVehicles;
using Houlight.Application.Features.Vehicles.Queries.GetVehicleById;
using Houlight.Application.Features.Vehicles.Queries.GetVehiclesByFilter;
using Houlight.Domain.Entities;

namespace Houlight.Application.Mapping;

public class VehicleMappingProfile : Profile
{
    public VehicleMappingProfile()
    {
        CreateMap<VehicleEntity, CreateVehicleResponse>();
        CreateMap<VehicleEntity, UpdateVehicleResponse>();
        CreateMap<VehicleEntity, GetAllVehiclesResponse>()
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => src.AssignedDriver != null ? $"{src.AssignedDriver.Name} {src.AssignedDriver.Surname}" : null));
        CreateMap<VehicleEntity, GetVehicleByIdResponse>()
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => src.AssignedDriver != null ? $"{src.AssignedDriver.Name} {src.AssignedDriver.Surname}" : null));
        CreateMap<VehicleEntity, GetVehiclesByFilterResponse>()
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => src.AssignedDriver != null ? $"{src.AssignedDriver.Name} {src.AssignedDriver.Surname}" : null));
        CreateMap<VehicleTypeEntity, VehicleTypeDto>();
    }
} 