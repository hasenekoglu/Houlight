using Houlight.Application.Features.Customers.Commands.CreateCustomer;
using Houlight.Application.Features.Customers.Commands.DeleteCustomer;
using Houlight.Application.Features.Customers.Commands.UpdateCustomer;
using Houlight.Application.Features.Customers.Commands.Login;
using Houlight.Application.Features.Customers.Queries.GetAllCustomers;
using Houlight.Application.Features.Customers.Queries.GetCustomerById;
using Houlight.Application.Features.Customers.Queries.GetCustomersByFilter;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoulightAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateCustomerCommandResponse>> Create([FromBody] CreateCustomerCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateCustomerCommandResponse>> Update(Guid id, [FromBody] UpdateCustomerCommand command)
    {
        if (id != command.Id)
            return BadRequest("Yol parametresi ile gövdedeki ID uyuşmuyor.");

        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        var command = new DeleteCustomerCommand { Id = id };
        var response = await _mediator.Send(command);
        
        if (response)
            return Ok(true);
            
        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCustomerByIdResponse>> GetById(Guid id)
    {
        var query = new GetCustomerByIdQuery { Id = id };
        var response = await _mediator.Send(query);
        
        if (response == null)
            return NotFound();
            
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllCustomersResponse>>> GetAll()
    {
        var query = new GetAllCustomersQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("filter")]
    public async Task<ActionResult<List<GetCustomersByFilterResponse>>> GetByFilter([FromQuery] GetCustomersByFilterQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCustomerCommand command)
    {
        if (command == null || string.IsNullOrEmpty(command.Email) || string.IsNullOrEmpty(command.Password))
            return BadRequest("Email ve şifre alanları zorunludur.");

        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
