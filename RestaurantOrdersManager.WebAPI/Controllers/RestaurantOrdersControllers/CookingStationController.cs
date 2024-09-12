using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;

namespace RestaurantOrdersManager.API.Controllers.RestaurantOrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookingStationController : ControllerBase
    {
        private readonly ICookingStationService _cookingStationService;

        public CookingStationController(ICookingStationService cookingStationService)
        {
            _cookingStationService = cookingStationService;
        }

        [HttpGet("GetAllCookingStationsWithPendingItems")]
        public async Task<IActionResult> GetAllCookingStationsWithPendingItems()
        {
            try
            {
                var result = await _cookingStationService.GetAllCookingStationsWithPendingItems();
                return Ok(result);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
