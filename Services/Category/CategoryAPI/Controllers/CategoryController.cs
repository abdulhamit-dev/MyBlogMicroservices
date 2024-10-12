
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

    // [HttpGet("GetById")]
    // public async Task<IActionResult> GetById(string id)
    // {
    //     var content = await _categoryService.GetById(id);
    //     return CreateActionResultInstance(content);
    // }
    //
    // [HttpPost("Create")]
    // public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
    // {
    //     var response = await _categoryService.Create(categoryCreateDto);
    //
    //     return CreateActionResultInstance(response);
    // }
    //
    // [HttpPut("Update")]
    // public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
    // {
    //     var response = await _categoryService.Update(categoryUpdateDto);
    //     return CreateActionResultInstance(response);
    // }
    //
    //
    // [HttpDelete("Delete")]
    // public async Task<IActionResult> Delete(string contentId)
    // {
    //     var response = await _categoryService.Delete(contentId);
    //     return CreateActionResultInstance(response);
    // }




}
