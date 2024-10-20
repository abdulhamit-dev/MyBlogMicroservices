
using Application.Features.Likes.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLib.ControllerBases;

namespace ReactionAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReactionController(IMediator mediator) : ControllerBase
{
    [HttpPost("Like")]
    public async Task<IActionResult> Create([FromBody] CreateLikeCommand createLikeCommand)
    {
        var response = await mediator.Send(createLikeCommand);
        return Ok(response);
    }
}
