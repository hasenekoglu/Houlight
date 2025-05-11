using Houlight.Application.Features.LoadOffers.Commands.AcceptLoadOffer;
using Houlight.Application.Features.LoadOffers.Commands.CreateLoadOffer;
using Houlight.Application.Features.LoadOffers.Commands.UpdateLoadOffer;
using Houlight.Application.Features.LoadOffers.Commands.DeleteLoadOffer;
using Houlight.Application.Features.LoadOffers.Queries.GetLoadOfferList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HoulightAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoadOffersController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoadOffersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetLoadOffers()
    {
        var userId = User.Claims.FirstOrDefault(x =>
            x.Type == "sub" ||
            x.Type == "nameidentifier" ||
            x.Type == "nameid" ||
            x.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        Guid? customerId = null;
        if (Guid.TryParse(userId, out var parsedId))
            customerId = parsedId;

        var query = new GetLoadOfferListQuery { CustomerId = customerId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLoadOffer([FromBody] CreateLoadOfferCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetLoadOffers), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLoadOffer(Guid id, [FromBody] UpdateLoadOfferCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("{id}/accept")]
    public async Task<IActionResult> AcceptLoadOffer(Guid id)
    {
        var command = new AcceptLoadOfferCommand { LoadOfferId = id };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("{id}/reject")]
    public async Task<IActionResult> RejectLoadOffer(Guid id)
    {
        var command = new DeleteLoadOfferCommand { Id = id };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLoadOffer(Guid id)
    {
        var command = new DeleteLoadOfferCommand { Id = id };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
} 