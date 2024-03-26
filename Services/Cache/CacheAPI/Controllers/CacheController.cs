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
        private readonly IConfiguration _configuration;

        public CacheController(IConfiguration configuration)
        {
            // _redis = ConnectionMultiplexer.Connect("172.30.0.10:6379");
            _configuration=configuration;
            _redis = ConnectionMultiplexer.Connect("Myblog_RedisDb:6379");
            _redis = ConnectionMultiplexer.Connect(_configuration["RedisConnection"]);
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

        [HttpGet("delete")]
        public IActionResult DeleteFromCache(string key)
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