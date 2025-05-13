using Houlight.Application.Features.LogisticsCompanies.Commands.CreateLogisticsCompany;
using Houlight.Application.Features.LogisticsCompanies.Commands.DeleteLogisticsCompany;
using Houlight.Application.Features.LogisticsCompanies.Commands.UpdateLogisticsCompany;
using Houlight.Application.Features.LogisticsCompanies.Queries.GetAllLogisticsCompanies;
using Houlight.Application.Features.LogisticsCompanies.Queries.GetLogisticsCompanyById;
using Houlight.Application.Features.LogisticsCompanies.Queries.GetLogisticsCompaniesByFilter;
using Houlight.Application.Features.LogisticsCompanies.Commands.Login;
using Houlight.Application.Features.Loads.Queries.GetLoadsByFilter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Houlight.Application.Features.Drivers.Queries.GetDriversByFilter;
using Houlight.Application.Features.Vehicles.Queries.GetVehiclesByFilter;
using Houlight.Application.Features.LogisticsCompanies.Commands.ChangePassword;

namespace HoulightAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LogisticsCompaniesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LogisticsCompaniesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<CreateLogisticsCompanyResponse>> Create([FromBody] CreateLogisticsCompanyCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateLogisticsCompanyResponse>> Update(Guid id, [FromBody] UpdateLogisticsCompanyCommand command)
    {
        if (id != command.Id)
            return BadRequest("Yol parametresi ile gövdedeki ID uyuşmuyor.");

        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        var command = new DeleteLogisticsCompanyCommand { Id = id };
        var response = await _mediator.Send(command);
        
        if (response)
            return Ok(true);
            
        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetLogisticsCompanyByIdResponse>> GetById(Guid id)
    {
        var query = new GetLogisticsCompanyByIdQuery { Id = id };
        var response = await _mediator.Send(query);
        
        if (response == null)
            return NotFound();
            
        return Ok(response);
    }

    [HttpGet("filter")]
    public async Task<ActionResult<List<GetLogisticsCompaniesByFilterResponse>>> GetByFilter([FromQuery] GetLogisticsCompaniesByFilterQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllLogisticsCompaniesResponse>>> GetAll()
    {
        var query = new GetAllLogisticsCompaniesQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCompanyCommand command)
    {
        if (command == null || string.IsNullOrEmpty(command.Email) || string.IsNullOrEmpty(command.Password))
            return BadRequest("Email ve şifre alanları zorunludur.");

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("profile")]
    public async Task<ActionResult<GetLogisticsCompanyByIdResponse>> GetProfile()
    {
        var userId = User.Claims.FirstOrDefault(x =>
            x.Type == "sub" ||
            x.Type == "nameidentifier" ||
            x.Type == "nameid" ||
            x.Type == ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedId))
            return Unauthorized(new { message = "Geçersiz oturum bilgisi. Lütfen tekrar giriş yapın." });

        var query = new GetLogisticsCompanyByIdQuery { Id = parsedId };
        var response = await _mediator.Send(query);
        
        if (response == null)
            return NotFound();
            
        return Ok(response);
    }

    [HttpGet("profile/loads")]
    public async Task<ActionResult<List<GetLoadsByFilterResponse>>> GetProfileLoads()
    {
        var userId = User.Claims.FirstOrDefault(x =>
            x.Type == "sub" ||
            x.Type == "nameidentifier" ||
            x.Type == "nameid" ||
            x.Type == ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedId))
            return Unauthorized(new { message = "Geçersiz oturum bilgisi. Lütfen tekrar giriş yapın." });

        var query = new GetLoadsByFilterQuery 
        { 
            LogisticsCompanyId = parsedId,
            Status = Houlight.Domain.Enums.LoadStatus.Pending // Aktif yükleri getir
        };
        
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("profile/offers")]
    public async Task<ActionResult<List<GetLoadsByFilterResponse>>> GetProfileOffers()
    {
        var userId = User.Claims.FirstOrDefault(x =>
            x.Type == "sub" ||
            x.Type == "nameidentifier" ||
            x.Type == "nameid" ||
            x.Type == ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedId))
            return Unauthorized(new { message = "Geçersiz oturum bilgisi. Lütfen tekrar giriş yapın." });

        var query = new GetLoadsByFilterQuery 
        { 
            LogisticsCompanyId = parsedId,
            Status = Houlight.Domain.Enums.LoadStatus.Accepted // Kabul edilmiş teklifleri getir
        };
        
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("profile/stats")]
    public async Task<ActionResult<object>> GetProfileStats()
    {
        var userId = User.Claims.FirstOrDefault(x =>
            x.Type == "sub" ||
            x.Type == "nameidentifier" ||
            x.Type == "nameid" ||
            x.Type == ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedId))
            return Unauthorized(new { message = "Geçersiz oturum bilgisi. Lütfen tekrar giriş yapın." });

        // Aktif yükler için sorgu
        var activeLoadsQuery = new GetLoadsByFilterQuery 
        { 
            LogisticsCompanyId = parsedId,
            Status = Houlight.Domain.Enums.LoadStatus.Pending
        };
        var activeLoads = await _mediator.Send(activeLoadsQuery);

        // Kabul edilmiş teklifler için sorgu
        var acceptedOffersQuery = new GetLoadsByFilterQuery 
        { 
            LogisticsCompanyId = parsedId,
            Status = Houlight.Domain.Enums.LoadStatus.Accepted
        };
        var acceptedOffers = await _mediator.Send(acceptedOffersQuery);

        // Sürücüler için sorgu
        var driversQuery = new GetDriversByFilterQuery 
        { 
            LogisticsCompanyId = parsedId
        };
        var drivers = await _mediator.Send(driversQuery);

        // Araçlar için sorgu
        var vehiclesQuery = new GetVehiclesByFilterQuery 
        { 
            LogisticsCompanyId = parsedId
        };
        var vehicles = await _mediator.Send(vehiclesQuery);

        return Ok(new
        {
            ActiveLoadsCount = activeLoads.Count,
            ActiveOffersCount = acceptedOffers.Count,
            DriversCount = drivers.Count,
            VehiclesCount = vehicles.Count
        });
    }

    [HttpPut("change-company-password")]
    public async Task<ActionResult<ChangeCompanyPasswordCommandResponse>> ChangeCompanyPassword([FromBody] ChangeCompanyPasswordCommand command)
    {
        var userIdClaim = User.Claims.FirstOrDefault(x =>
            x.Type == "sub" ||
            x.Type == "nameidentifier" ||
            x.Type == "nameid" ||
            x.Type == ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
            return Unauthorized();

        command.Id = Guid.Parse(userIdClaim.Value);
        var response = await _mediator.Send(command);
        return Ok(response);
    }
} 