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
        private readonly ContentService _contentService;

        public ContentController(ContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet("get")]
        public async Task<ActionResult> Get()
        {
            var contents = await _contentService.GetAllAsync();
            return Ok(contents);
        }

        [HttpPost("save")]
        public async Task<ActionResult> Save(Content content)
        {
            var result = await _contentService.SaveAsync(content);
            return Ok(result);
        }
    }
}