using Houlight.Application.Features.Vehicles.Commands.CreateVehicle;
using Houlight.Application.Features.Vehicles.Commands.DeleteVehicle;
using Houlight.Application.Features.Vehicles.Commands.UpdateVehicle;
using Houlight.Application.Features.Vehicles.Queries.GetAllVehicles;
using Houlight.Application.Features.Vehicles.Queries.GetVehicleById;
using Houlight.Application.Features.Vehicles.Queries.GetVehiclesByFilter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Houlight.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiclesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateVehicleResponse>> Create([FromBody] CreateVehicleCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateVehicleResponse>> Update(Guid id, [FromBody] UpdateVehicleCommand command)
    {
        if (id != command.Id)
            return BadRequest("Yol parametresi ile gövdedeki ID uyuşmuyor.");

        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        var command = new DeleteVehicleCommand { Id = id };
        var response = await _mediator.Send(command);
        
        if (response)
            return Ok(true);
            
        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetVehicleByIdResponse>> GetById(Guid id)
    {
        var query = new GetVehicleByIdQuery { Id = id };
        var response = await _mediator.Send(query);
        
        if (response == null)
            return NotFound();
            
        return Ok(response);
    }

    [HttpGet("filter")]
    public async Task<ActionResult<List<GetVehiclesByFilterResponse>>> GetByFilter([FromQuery] GetVehiclesByFilterQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllVehiclesResponse>>> GetAll()
    {
        var query = new GetAllVehiclesQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }
} 