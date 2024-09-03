using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersDTO.CookingStationDTO;
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

        [HttpGet("cookingStations")]
        public async Task<IActionResult> cookingStations()
        {
            try
            {
                var result = await _cookingStationService.GetAllCookingStations();
                return Ok(result);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("ordersInCookingStation")]
        public async Task<IActionResult> cookingStations(int idcookingStationId)
        {
            try
            {
                var result = await _cookingStationService.GetItemsInCookingStation(idcookingStationId);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
