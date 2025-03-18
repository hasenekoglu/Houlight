using MediatR;

namespace Houlight.Application.Features.Drivers.Commands.DeleteDriver;

public class DeleteDriverCommand : IRequest<bool>
{
    public Guid Id { get; set; }
} 