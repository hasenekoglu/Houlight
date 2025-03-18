using AutoMapper;
using Houlight.Application.Features.VehicleTypes.Commands.CreateVehicleType;
using Houlight.Application.Features.VehicleTypes.Commands.UpdateVehicleType;
using Houlight.Application.Features.VehicleTypes.Queries.GetAllVehicleTypes;
using Houlight.Application.Features.VehicleTypes.Queries.GetVehicleTypeById;
using Houlight.Application.Features.VehicleTypes.Queries.GetVehicleTypesByFilter;
using Houlight.Domain.Entities;

namespace Houlight.Application.Mapping;

public class VehicleTypeMappingProfile : Profile
{
    public VehicleTypeMappingProfile()
    {
        CreateMap<VehicleTypeEntity, CreateVehicleTypeResponse>();
        CreateMap<VehicleTypeEntity, UpdateVehicleTypeResponse>();
        CreateMap<VehicleTypeEntity, GetAllVehicleTypesResponse>();
        CreateMap<VehicleTypeEntity, GetVehicleTypeByIdResponse>();
        CreateMap<VehicleTypeEntity, GetVehicleTypesByFilterResponse>();
    }
} 