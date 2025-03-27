using AutoMapper;
using Houlight.Application.Features.Loads.Commands.CreateLoad;
using Houlight.Application.Features.Loads.Commands.CustomerLoadUpdate;
using Houlight.Application.Features.Loads.Commands.DeleteLoad;
using Houlight.Application.Features.Loads.Commands.LogisticsCompanyLoadUpdate;
using Houlight.Application.Features.Loads.Queries.GetAllLoads;
using Houlight.Application.Features.Loads.Queries.GetLoadById;
using Houlight.Application.Features.Loads.Queries.GetLoadsByFilter;
using Houlight.Domain.Entities;

namespace Houlight.Application.Mapping;

public class LoadMappingProfile : Profile
{
    public LoadMappingProfile()
    {
        CreateMap<LoadEntity, CreateLoadResponse>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerEntity.Name))
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity != null ? src.LogisticsCompanyEntity.CompanyName : null))
            .ForMember(dest => dest.AssignedVehiclePlate, opt => opt.MapFrom(src => src.VehicleEntity != null ? src.VehicleEntity.PlateNumber : null))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => 
                src.DriverEntity != null ? $"{src.DriverEntity.Name} {src.DriverEntity.Surname}" : null));

        CreateMap<CreateLoadCommand, LoadEntity>();

        CreateMap<LoadEntity, CustomerLoadUpdateResponse>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerEntity.Name))
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity != null ? src.LogisticsCompanyEntity.CompanyName : null))
            .ForMember(dest => dest.AssignedVehiclePlate, opt => opt.MapFrom(src => src.VehicleEntity != null ? src.VehicleEntity.PlateNumber : null))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => 
                src.DriverEntity != null ? $"{src.DriverEntity.Name} {src.DriverEntity.Surname}" : null));

        CreateMap<CustomerLoadUpdateCommand, LoadEntity>();

        CreateMap<LoadEntity, LogisticsCompanyLoadUpdateResponse>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerEntity.Name))
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity != null ? src.LogisticsCompanyEntity.CompanyName : null))
            .ForMember(dest => dest.AssignedVehiclePlate, opt => opt.MapFrom(src => src.VehicleEntity != null ? src.VehicleEntity.PlateNumber : null))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => 
                src.DriverEntity != null ? $"{src.DriverEntity.Name} {src.DriverEntity.Surname}" : null));

        CreateMap<LogisticsCompanyLoadUpdateCommand, LoadEntity>();

        CreateMap<LoadEntity, GetAllLoadsResponse>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerEntity.Name))
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity != null ? src.LogisticsCompanyEntity.CompanyName : null))
            .ForMember(dest => dest.AssignedVehiclePlate, opt => opt.MapFrom(src => src.VehicleEntity != null ? src.VehicleEntity.PlateNumber : null))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => 
                src.DriverEntity != null ? $"{src.DriverEntity.Name} {src.DriverEntity.Surname}" : null));

        CreateMap<LoadEntity, GetLoadByIdResponse>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerEntity.Name))
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity != null ? src.LogisticsCompanyEntity.CompanyName : null))
            .ForMember(dest => dest.AssignedVehiclePlate, opt => opt.MapFrom(src => src.VehicleEntity != null ? src.VehicleEntity.PlateNumber : null))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => 
                src.DriverEntity != null ? $"{src.DriverEntity.Name} {src.DriverEntity.Surname}" : null));

        CreateMap<LoadEntity, GetLoadsByFilterResponse>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerEntity.Name))
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity != null ? src.LogisticsCompanyEntity.CompanyName : null))
            .ForMember(dest => dest.AssignedVehiclePlate, opt => opt.MapFrom(src => src.VehicleEntity != null ? src.VehicleEntity.PlateNumber : null))
            .ForMember(dest => dest.AssignedDriverName, opt => opt.MapFrom(src => 
                src.DriverEntity != null ? $"{src.DriverEntity.Name} {src.DriverEntity.Surname}" : null));
    }
} 