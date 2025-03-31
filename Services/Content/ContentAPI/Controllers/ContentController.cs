using Application.Features.Content.Commands.Create;
using Application.Features.Content.Commands.Delete;
using Application.Features.Content.Commands.Update;
using Application.Features.Content.Queries.GetAll;
using Application.Features.Content.Queries.GetAllByCategoryId;
using Application.Features.Content.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContentAPI.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class ContentController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var contents = await _mediator.Send(new GetAllContentQuery());
        return Ok(contents);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery]GetByIdQuery getByIdQuery)
    {
       var content = await _mediator.Send(getByIdQuery);
       return Ok(content);
    }
    

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateContentCommand createContentCommand)
    {
        var response = await _mediator.Send(createContentCommand);
        return Ok(response);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(UpdateContentCommand updateContentCommand)
    {
        var response = await _mediator.Send(updateContentCommand);
        return Ok(response);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(DeleteContentCommand deleteContentCommand)
    {
        var response = await _mediator.Send(deleteContentCommand);
        return Ok(response);
    }

}
