using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using Application.Features.Comments.Queries.GetAllByContentId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommentControllerAPI.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class CommentController(IMediator mediator) : ControllerBase
{
    // [HttpGet("GetAll")]
    // public async Task<IActionResult> GetAll()
    // {
    //     var contents = await _commentService.GetAll();
    //     return CreateActionResultInstance(contents);
    // }
    //
    // [HttpGet("GetById")]
    // public async Task<IActionResult> GetAllByContentId([] contentId)
    // {
    //     var contents = await _commentService.GetAllByContentId(contentId);
    //     return CreateActionResultInstance(contents);
    // }

    [HttpGet("GetAllByContentId")]
    public async Task<IActionResult> GetById([FromQuery]GetAllByContentIdQuery getAllByContentIdQuery)
    {
        var response = await mediator.Send(getAllByContentIdQuery);
        return Ok(response);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody]CreateCommentCommand createCommentCommand)
    {
        var response = await mediator.Send(createCommentCommand);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody]UpdateCommentCommand updateCommentCommand)
    {
        var response = await mediator.Send(updateCommentCommand);
        return Ok(response);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody]DeleteCommentCommand deleteCommentCommand)
    {
        var response = await mediator.Send(deleteCommentCommand);
        return Ok(response);
    } 
}
