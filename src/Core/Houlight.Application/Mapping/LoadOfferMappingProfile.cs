using AutoMapper;
using Houlight.Application.Features.LoadOffers.Commands.UpdateLoadOffer;
using Houlight.Application.Features.LoadOffers.Queries.GetLoadOfferList;
using Houlight.Domain.Entities;
using Houlight.Domain.Enums;

namespace Houlight.Application.Mapping;

public class LoadOfferMappingProfile : Profile
{
    public LoadOfferMappingProfile()
    {
        CreateMap<LoadOfferEntity, LoadOfferListDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.LoadId, opt => opt.MapFrom(src => src.LoadId))
            .ForMember(dest => dest.LoadStatus, opt => opt.MapFrom(src => src.LoadEntity.Status))
            .ForMember(dest => dest.IsAccepted, opt => opt.MapFrom(src => 
                src.LoadEntity.Status == LoadStatus.Accepted && 
                src.LoadEntity.LogisticsCompanyId == src.LogisticsCompanyId))
            .ForMember(dest => dest.FromLocation, opt => opt.MapFrom(src => src.LoadEntity.FromLocation))
            .ForMember(dest => dest.ToLocation, opt => opt.MapFrom(src => src.LoadEntity.ToLocation))
            .ForMember(dest => dest.LoadType, opt => opt.MapFrom(src => src.LoadEntity.LoadType))
            .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.LoadEntity.Weight))
            .ForMember(dest => dest.Volume, opt => opt.MapFrom(src => src.LoadEntity.Volume))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DeliveryDate, opt => opt.MapFrom(src => src.LoadEntity.DeliveryDate))
            .ForMember(dest => dest.CustomerExpectedPrice, opt => opt.MapFrom(src => src.LoadEntity.CustomerExpectedPrice))
            .ForMember(dest => dest.CompanyOfferedPrice, opt => opt.MapFrom(src => src.CompanyOfferedPrice))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerEntity.Name))
            .ForMember(dest => dest.LogisticsCompanyName, opt => opt.MapFrom(src => src.LogisticsCompanyEntity.CompanyName))
            .ForMember(dest => dest.VehiclePlate, opt => opt.MapFrom(src => src.VehicleEntity != null ? src.VehicleEntity.PlateNumber : null))
            .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.DriverEntity != null ? src.DriverEntity.Name : null))
            .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
            .ForMember(dest => dest.LogisticsCompanyId, opt => opt.MapFrom(src => src.LogisticsCompanyId))
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.OfferStatus, opt => opt.MapFrom(src => src.OfferStatus));

        CreateMap<UpdateLoadOfferCommand, LoadOfferEntity>()
            .ForMember(dest => dest.CompanyOfferedPrice, opt => opt.MapFrom(src => src.CompanyOfferedPrice))
            .ForMember(dest => dest.AssignedVehicleId, opt => opt.MapFrom(src => src.AssignedVehicleId))
            .ForMember(dest => dest.AssignedDriverId, opt => opt.MapFrom(src => src.AssignedDriverId));
    }
} 