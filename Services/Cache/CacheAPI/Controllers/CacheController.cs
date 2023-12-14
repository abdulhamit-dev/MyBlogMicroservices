using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacheAPI.Models;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly ConnectionMultiplexer _redis;

        public CacheController()
        {
            _redis = ConnectionMultiplexer.Connect("localhost");
        }

        [HttpPost("add")]
        public IActionResult AddToCache(CacheDto cacheDto)
        {
            var database = _redis.GetDatabase();
            var isSuccess = database.StringSet(cacheDto.Key, cacheDto.Value, TimeSpan.FromSeconds(cacheDto.ExpirySeconds));

            if (isSuccess)
                return Ok("added");
            else
                return BadRequest("error");
        }

        [HttpGet("get")]
        public IActionResult GetFromCache(string key)
        {
            var database = _redis.GetDatabase();
            var value = database.StringGet(key);

            if (value.HasValue)
                return Ok(value.ToString());
            else
                return NotFound("not found");
        }

        [HttpDelete("delete")]
        public IActionResult DeleteFromCache([FromQuery] string key)
        {
            var database = _redis.GetDatabase();
            var isDeleted = database.KeyDelete(key);

            if (isDeleted)
                return Ok("deleted");
            else
                return NotFound("not found");
        }
    }
}