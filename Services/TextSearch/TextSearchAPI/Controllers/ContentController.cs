using Microsoft.AspNetCore.Mvc;
using SharedLib.ControllerBases;
using TextSearchAPI.Models;
using TextSearchAPI.Services;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : CustomBaseController
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var contents = await _contentService.GetAllAsync();
            return CreateActionResultInstance(contents);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchText)
        {
            var contents = await _contentService.SearchAsync(searchText);
            return CreateActionResultInstance(contents);
        }
    }
}