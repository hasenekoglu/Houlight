using Houlight.Application.Features.Loads.Commands.CreateLoad;
using Houlight.Application.Features.Loads.Commands.CustomerLoadUpdate;
using Houlight.Application.Features.Loads.Commands.DeleteLoad;
using Houlight.Application.Features.Loads.Queries.GetAllLoads;
using Houlight.Application.Features.Loads.Queries.GetLoadById;
using Houlight.Application.Features.Loads.Queries.GetLoadsByFilter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HoulightAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoadsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoadsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLoads()
    {
        var query = new GetAllLoadsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLoadById(Guid id)
    {
        var query = new GetLoadByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetLoadsByFilter([FromQuery] GetLoadsByFilterQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLoad([FromBody] CreateLoadCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetLoadById), new { id = result.Id }, result);
    }

    [HttpPut("customer/{id}")]
    public async Task<IActionResult> UpdateLoadByCustomer(Guid id, [FromBody] CustomerLoadUpdateCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLoad(Guid id)
    {
        var command = new DeleteLoadCommand { Id = id };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
} 