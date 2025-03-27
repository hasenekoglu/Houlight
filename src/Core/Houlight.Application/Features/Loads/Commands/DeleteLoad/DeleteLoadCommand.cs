using MediatR;

namespace Houlight.Application.Features.Loads.Commands.DeleteLoad;

public class DeleteLoadCommand : IRequest<bool>
{
    public Guid Id { get; set; }
} 