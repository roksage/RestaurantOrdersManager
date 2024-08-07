using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using System;

namespace RestaurantOrdersManager.API.Controllers.ReservationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ITableService _tableService;

        public ReservationController(IMemoryCache memoryCache, ITableService tableService)
        {
            _memoryCache = memoryCache;
            _tableService = tableService;
        }

        private string SetValueToCache(string code, string value)
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(3),
                SlidingExpiration = TimeSpan.FromMinutes(2),
                Priority = CacheItemPriority.High
            };
            var a = _memoryCache.Set(code, value , cacheExpiryOptions);
            return a;
        }

        private string GetValueFromCache(string code)
        {
            var value = string.Empty;
            _memoryCache.TryGetValue(code, out value);
            return value;
        }

        private void RemoveValueFromCache(int code)
        {
            _memoryCache.Remove(code);
        }

        [HttpPost("add")]
        public async Task<IActionResult> add(string value) 
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXY";
            var stringChars = new char[4];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var code = new String(stringChars);



            string result = SetValueToCache(code, value);

            return Ok(code);
        }

        [HttpGet("getByCode/{code}")]
        public async Task<IActionResult> getByCode(string code)
        {
            string value = GetValueFromCache(code);   
            if (value == null)
            {
                return StatusCode(404, "code expired");
            }
            return Ok(value);
        }
    }
}
