using MediatR;

namespace Houlight.Application.Features.Loads.Queries.GetLoadById;

public class GetLoadByIdQuery : IRequest<GetLoadByIdResponse>
{
    public Guid Id { get; set; }
} 