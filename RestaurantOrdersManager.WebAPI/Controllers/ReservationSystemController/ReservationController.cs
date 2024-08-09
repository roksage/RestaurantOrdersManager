using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemServices;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;
using System;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly RestaurantOrdersDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;
        private readonly IReservationSystem _reservationSystem;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IMemoryCache memoryCache, IReservationSystem reservationSystem, ILogger<ReservationController> logger, RestaurantOrdersDbContext dbContext)
        {
            _memoryCache = memoryCache;
            _logger = logger;
            _dbContext = dbContext;
            _reservationSystem = reservationSystem;
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


        [HttpPost("reserveTable")]
        public async Task<ReservationResponse> reserveTable(ReservationCreateRequest request)
        {
            ReservationResponse reserve = await _reservationSystem.CreateReservation(request);

            return reserve;
        }


        //needs update
        [HttpGet("getreservations")]
        public async Task<ActionResult<IEnumerable<(DateTime start, DateTime end)>>> GetFreeSlots()
        {
            return Ok();
        }

    }
}