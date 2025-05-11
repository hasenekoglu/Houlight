using Houlight.Application.Features.Loads.Commands.CreateLoad;
using Houlight.Application.Features.Loads.Commands.CustomerLoadUpdate;
using Houlight.Application.Features.Loads.Commands.DeleteLoad;
using Houlight.Application.Features.Loads.Queries.GetAllLoads;
using Houlight.Application.Features.Loads.Queries.GetLoadById;
using Houlight.Application.Features.Loads.Queries.GetLoadsByFilter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FluentValidation;

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
    [Authorize]
    public async Task<IActionResult> GetLoadsByFilter([FromQuery] GetLoadsByFilterQuery query)
    {
        var userId = User.Claims.FirstOrDefault(x =>
            x.Type == "sub" ||
            x.Type == "nameidentifier" ||
            x.Type == "nameid" ||
            x.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedId))
        {
            return Unauthorized(new { message = "Geçersiz oturum bilgisi. Lütfen tekrar giriş yapın." });
        }

        query.CustomerId = parsedId;
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateLoad([FromBody] CreateLoadCommand command)
    {
        try
        {
            if (command == null)
            {
                Console.WriteLine("CreateLoad: Command null");
                return BadRequest(new { message = "Yük bilgileri boş olamaz." });
            }

            Console.WriteLine($"CreateLoad: Command içeriği - FromLocation: {command.FromLocation}, ToLocation: {command.ToLocation}, Weight: {command.Weight}, Volume: {command.Volume}");

            var userId = User.Claims.FirstOrDefault(x =>
                x.Type == "sub" ||
                x.Type == "nameidentifier" ||
                x.Type == "nameid" ||
                x.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedId))
            {
                Console.WriteLine($"CreateLoad: Geçersiz userId - {userId}");
                return Unauthorized(new { message = "Geçersiz oturum bilgisi. Lütfen tekrar giriş yapın." });
            }

            command.CustomerId = parsedId;

            try
            {
                var result = await _mediator.Send(command);
                Console.WriteLine($"CreateLoad: Başarılı - Yük ID: {result.Id}");
                return CreatedAtAction(nameof(GetLoadById), new { id = result.Id }, result);
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"CreateLoad: Validasyon hatası - {ex.Message}");
                foreach (var error in ex.Errors)
                {
                    Console.WriteLine($"Validasyon hatası - {error.PropertyName}: {error.ErrorMessage}");
                }
                return BadRequest(new { message = ex.Message, errors = ex.Errors.Select(e => new { field = e.PropertyName, message = e.ErrorMessage }) });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"CreateLoad: Beklenmeyen hata - {ex}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            return StatusCode(500, new { message = "Yük eklenirken bir hata oluştu. Lütfen daha sonra tekrar deneyin." });
        }
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