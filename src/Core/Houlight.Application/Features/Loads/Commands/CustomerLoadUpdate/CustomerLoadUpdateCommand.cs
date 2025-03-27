using Houlight.Domain.Enums;
using MediatR;

namespace Houlight.Application.Features.Loads.Commands.CustomerLoadUpdate;

public class CustomerLoadUpdateCommand : IRequest<CustomerLoadUpdateResponse>
{
    public Guid Id { get; set; }
    public string FromLocation { get; set; }
    public string ToLocation { get; set; }
    public LoadType LoadType { get; set; }
    public int Weight { get; set; }
    public int Volume { get; set; }
    public string? Description { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public decimal? CustomerExpectedPrice { get; set; }
} 