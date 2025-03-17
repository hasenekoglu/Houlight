using Houlight.Application.Features.LogisticsCompanies.Commands.CreateLogisticsCompany;
using Houlight.Application.Features.LogisticsCompanies.Commands.DeleteLogisticsCompany;
using Houlight.Application.Features.LogisticsCompanies.Commands.UpdateLogisticsCompany;
using Houlight.Application.Features.LogisticsCompanies.Queries.GetAllLogisticsCompanies;
using Houlight.Application.Features.LogisticsCompanies.Queries.GetLogisticsCompanyById;
using Houlight.Application.Features.LogisticsCompanies.Queries.GetLogisticsCompaniesByFilter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Houlight.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogisticsCompaniesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LogisticsCompaniesController(IMediator mediator)
    {
        _mediator = mediator;
    }

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
} 