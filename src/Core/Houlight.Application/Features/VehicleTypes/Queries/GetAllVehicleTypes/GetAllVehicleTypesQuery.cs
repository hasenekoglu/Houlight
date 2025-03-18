using MediatR;

namespace Houlight.Application.Features.VehicleTypes.Queries.GetAllVehicleTypes;

public class GetAllVehicleTypesQuery : IRequest<List<GetAllVehicleTypesResponse>>
{
}

public class GetAllVehicleTypesResponse
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
} 