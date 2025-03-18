using MediatR;

namespace Houlight.Application.Features.VehicleTypes.Queries.GetVehicleTypesByFilter;

public class GetVehicleTypesByFilterQuery : IRequest<List<GetVehicleTypesByFilterResponse>>
{
    public string? SearchTerm { get; set; }
    public string? Type { get; set; }
}

public class GetVehicleTypesByFilterResponse
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
} 