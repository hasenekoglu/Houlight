using MediatR;

namespace Houlight.Application.Features.Vehicles.Queries.GetVehiclesByCompany;

public class GetVehiclesByCompanyQuery : IRequest<List<GetVehiclesByCompanyResponse>>
{
    public Guid CompanyId { get; set; }
} 