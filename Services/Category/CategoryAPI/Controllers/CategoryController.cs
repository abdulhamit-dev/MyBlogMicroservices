
using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using CategoryAPI.Models.Dtos;
using CategoryAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLib.ControllerBases;

namespace CategoryAPI.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMediator _mediator;
    public CategoryController(ICategoryService categoryService, IMediator mediator)
    {
        _categoryService = categoryService;
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var list= await _mediator.Send(new GetListCategoryQuery());
        return Ok(list);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery]GetByIdCategoryQuery getByIdCategoryQuery)
    {
        var response = await _mediator.Send(getByIdCategoryQuery);
        return Ok(response);
    }
    
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody]CreateCategoryCommand createCategoryCommand)
    {
        var response = await _mediator.Send(createCategoryCommand);
        return Ok(response);
    }
    
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody]UpdateCategoryCommand updateCategoryCommand)
    {
       var response = await _mediator.Send(updateCategoryCommand);
       return Ok(response);
    }
    
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody]DeleteCategoryCommand deleteCategoryCommand)
    {
        var response = await _mediator.Send(deleteCategoryCommand);
        return Ok(response);
    }
    
}
