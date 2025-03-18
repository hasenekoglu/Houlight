using MediatR;

namespace Houlight.Application.Features.VehicleTypes.Queries.GetVehicleTypeById;

public class GetVehicleTypeByIdQuery : IRequest<GetVehicleTypeByIdResponse>
{
    public Guid Id { get; set; }
}

public class GetVehicleTypeByIdResponse
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
} 