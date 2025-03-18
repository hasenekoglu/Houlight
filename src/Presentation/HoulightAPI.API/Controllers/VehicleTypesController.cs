using Houlight.Application.Features.VehicleTypes.Commands.CreateVehicleType;
using Houlight.Application.Features.VehicleTypes.Commands.DeleteVehicleType;
using Houlight.Application.Features.VehicleTypes.Commands.UpdateVehicleType;
using Houlight.Application.Features.VehicleTypes.Queries.GetAllVehicleTypes;
using Houlight.Application.Features.VehicleTypes.Queries.GetVehicleTypeById;
using Houlight.Application.Features.VehicleTypes.Queries.GetVehicleTypesByFilter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Houlight.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehicleTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateVehicleTypeResponse>> Create([FromBody] CreateVehicleTypeCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateVehicleTypeResponse>> Update(Guid id, [FromBody] UpdateVehicleTypeCommand command)
    {
        if (id != command.Id)
            return BadRequest("Yol parametresi ile gövdedeki ID uyuşmuyor.");

        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        var command = new DeleteVehicleTypeCommand { Id = id };
        var response = await _mediator.Send(command);
        
        if (response)
            return Ok(true);
            
        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetVehicleTypeByIdResponse>> GetById(Guid id)
    {
        var query = new GetVehicleTypeByIdQuery { Id = id };
        var response = await _mediator.Send(query);
        
        if (response == null)
            return NotFound();
            
        return Ok(response);
    }

    [HttpGet("filter")]
    public async Task<ActionResult<List<GetVehicleTypesByFilterResponse>>> GetByFilter([FromQuery] GetVehicleTypesByFilterQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllVehicleTypesResponse>>> GetAll()
    {
        var query = new GetAllVehicleTypesQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }
} 