using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using System;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ITableService _tableService;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IMemoryCache memoryCache, ITableService tableService, ILogger<ReservationController> logger)
        {
            _memoryCache = memoryCache;
            _tableService = tableService;
            _logger = logger;
        }


        private string SetValueToCache(string code, string value)
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                SlidingExpiration = TimeSpan.FromMinutes(1),
                Priority = CacheItemPriority.High,
            };
            return _memoryCache.Set(code, value, cacheExpiryOptions);
        }

        private string GetValueFromCache(string code)
        {
            _memoryCache.TryGetValue(code, out string value);
            return value;
        }

        private void RemoveValueFromCache(string code)
        {
            _memoryCache.Remove(code);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(string value)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXY";
            var stringChars = new char[4];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var code = new string(stringChars);

            string result = SetValueToCache(code, value);
            _logger.LogInformation($"Added cache entry with code: {code}");

            return Ok(code);
        }

        [HttpGet("getByCode/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            string value = GetValueFromCache(code);
            if (value == null)
            {
                _logger.LogInformation($"Code {code} was not found, expired or wrong one");
                return NotFound("code expired");
            }
            RemoveValueFromCache(code);
            return Ok(value);
        }
    }
}