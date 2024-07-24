using Azure;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;

namespace RestaurantOrdersManager.WebAPI.Controllers.RestaurantOrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : Controller
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }


        [HttpPost("addIngredient")]

        public async Task<IActionResult> addIngredient(IngredientAddRequest request)
        {
            try
            {
                IngredientResponse response = await _ingredientService.CreateIngredient(request);
                return Ok(new IngredientResponse
                {
                    IngredientId = response.IngredientId,
                    IngredientName = response.IngredientName,
                    IngredientAmount = response.IngredientAmount,
                    IngredientUnit = response.IngredientUnit,
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpPost("deleteIngredient")]

        public async Task<IActionResult> deleteIngredient(IngredientDeleteRequest request)
        {
            try
            {
                bool deleteRequest = await _ingredientService.DeleteIngredient(request);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpGet("getAllIngredient")]

        public async Task<IActionResult> getAllIngredient()
        {
            try
            {
                IEnumerable<IngredientResponse> allIngredients = await _ingredientService.GetAllIngredients();

                return Ok(allIngredients);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }


        [HttpPut("updateIngredient")]

        public async Task<IActionResult> updateIngredient(IngredientUpdateRequest request)
        {
            try
            {
                IngredientResponse response = await _ingredientService.UpdateIngredient(request);

                return Ok(new IngredientResponse
                {
                    IngredientId = response.IngredientId,
                    IngredientName = response.IngredientName,
                    IngredientAmount = response.IngredientAmount,
                    IngredientUnit = response.IngredientUnit,
                });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

    }
}
