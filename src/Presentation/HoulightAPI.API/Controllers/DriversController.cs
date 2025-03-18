using Houlight.Application.Features.Drivers.Commands.CreateDriver;
using Houlight.Application.Features.Drivers.Commands.DeleteDriver;
using Houlight.Application.Features.Drivers.Commands.UpdateDriver;
using Houlight.Application.Features.Drivers.Queries.GetAllDrivers;
using Houlight.Application.Features.Drivers.Queries.GetDriverById;
using Houlight.Application.Features.Drivers.Queries.GetDriversByFilter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Houlight.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly IMediator _mediator;

    public DriversController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateDriverResponse>> Create([FromBody] CreateDriverCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateDriverResponse>> Update(Guid id, [FromBody] UpdateDriverCommand command)
    {
        if (id != command.Id)
            return BadRequest("Yol parametresi ile gövdedeki ID uyuşmuyor.");

        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        var command = new DeleteDriverCommand { Id = id };
        var response = await _mediator.Send(command);
        
        if (response)
            return Ok(true);
            
        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetDriverByIdResponse>> GetById(Guid id)
    {
        var query = new GetDriverByIdQuery { Id = id };
        var response = await _mediator.Send(query);
        
        if (response == null)
            return NotFound();
            
        return Ok(response);
    }

    [HttpGet("filter")]
    public async Task<ActionResult<List<GetDriversByFilterResponse>>> GetByFilter([FromQuery] GetDriversByFilterQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllDriversResponse>>> GetAll()
    {
        var query = new GetAllDriversQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }
} 