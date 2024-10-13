
using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CategoryAPI.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class CategoryController(IMediator mediator) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery]GetListCategoryQuery getListCategoryQuery)
    {
        var list= await mediator.Send(getListCategoryQuery);
        return Ok(list);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery]GetByIdCategoryQuery getByIdCategoryQuery)
    {
        var response = await mediator.Send(getByIdCategoryQuery);
        return Ok(response);
    }
    
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody]CreateCategoryCommand createCategoryCommand)
    {
        var response = await mediator.Send(createCategoryCommand);
        return Ok(response);
    }
    
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody]UpdateCategoryCommand updateCategoryCommand)
    {
       var response = await mediator.Send(updateCategoryCommand);
       return Ok(response);
    }
    
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody]DeleteCategoryCommand deleteCategoryCommand)
    {
        var response = await mediator.Send(deleteCategoryCommand);
        return Ok(response);
    }
    
}
