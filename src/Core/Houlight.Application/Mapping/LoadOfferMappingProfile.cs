using AutoMapper;
using Houlight.Application.Features.LoadOffers.Queries.GetLoadOfferList;
using Houlight.Domain.Entities;

namespace Houlight.Application.Mapping;

public class LoadOfferMappingProfile : Profile
{
    public LoadOfferMappingProfile()
    {
        CreateMap<LoadOfferEntity, LoadOfferListDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FromLocation, opt => opt.MapFrom(src => src.FromLocation))
            .ForMember(dest => dest.ToLocation, opt => opt.MapFrom(src => src.ToLocation))
            .ForMember(dest => dest.LoadType, opt => opt.MapFrom(src => src.LoadType))
            .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
            .ForMember(dest => dest.Volume, opt => opt.MapFrom(src => src.Volume))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DeliveryDate, opt => opt.MapFrom(src => src.DeliveryDate))
            .ForMember(dest => dest.CustomerExpectedPrice, opt => opt.MapFrom(src => src.CustomerExpectedPrice))
            .ForMember(dest => dest.CompanyOfferedPrice, opt => opt.MapFrom(src => src.CompanyOfferedPrice))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerEntity.Name))
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName))
            .ForMember(dest => dest.VehiclePlate, opt => opt.MapFrom(src => src.VehicleEntity != null ? src.VehicleEntity.PlateNumber : null))
            .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.DriverEntity != null ? src.DriverEntity.Name : null));
    }
} 