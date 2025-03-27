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
        CreateMap<VehicleEntity, CreateVehicleResponse>()
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName))
             .ForMember(dest => dest.VehicleTypeType, opt => opt.MapFrom(src => src.VehicleTypeEntity.Type))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => 
                src.AssignedDriver != null ? $"{src.AssignedDriver.Name} {src.AssignedDriver.Surname}" : null))
            .ReverseMap();

        CreateMap<VehicleEntity, UpdateVehicleResponse>()
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName))
              .ForMember(dest => dest.VehicleTypeType, opt => opt.MapFrom(src => src.VehicleTypeEntity.Type))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => 
                src.AssignedDriver != null ? $"{src.AssignedDriver.Name} {src.AssignedDriver.Surname}" : null))   
            .ReverseMap();;

        CreateMap<VehicleEntity, GetAllVehiclesResponse>()
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName))
              .ForMember(dest => dest.VehicleTypeType, opt => opt.MapFrom(src => src.VehicleTypeEntity.Type))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => 
                src.AssignedDriver != null ? $"{src.AssignedDriver.Name} {src.AssignedDriver.Surname}" : null))   
            .ReverseMap();;

        CreateMap<VehicleEntity, GetVehicleByIdResponse>()
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName))
              .ForMember(dest => dest.VehicleTypeType, opt => opt.MapFrom(src => src.VehicleTypeEntity.Type))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => 
                src.AssignedDriver != null ? $"{src.AssignedDriver.Name} {src.AssignedDriver.Surname}" : null))   
            .ReverseMap();;

        CreateMap<VehicleEntity, GetVehiclesByFilterResponse>()
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName))
              .ForMember(dest => dest.VehicleTypeType, opt => opt.MapFrom(src => src.VehicleTypeEntity.Type))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => 
                src.AssignedDriver != null ? $"{src.AssignedDriver.Name} {src.AssignedDriver.Surname}" : null))   
            .ReverseMap();;
    }
} 