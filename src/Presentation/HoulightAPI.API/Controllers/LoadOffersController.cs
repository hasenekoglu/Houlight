using Houlight.Application.Features.LoadOffers.Commands.AcceptLoadOffer;
using Houlight.Application.Features.LoadOffers.Commands.CreateLoadOffer;
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
    public async Task<IActionResult> GetLoadOffers([FromQuery] GetLoadOfferListQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLoadOffer([FromBody] CreateLoadOfferCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetLoadOffers), new { id = result.Id }, result);
    }

    [HttpPost("{id}/accept")]
    public async Task<IActionResult> AcceptLoadOffer(Guid id)
    {
        var command = new AcceptLoadOfferCommand { LoadOfferId = id };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
} 