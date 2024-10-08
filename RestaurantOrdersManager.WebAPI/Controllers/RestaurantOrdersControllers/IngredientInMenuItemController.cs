﻿using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientInMenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;

namespace RestaurantOrdersManager.WebAPI.Controllers.RestaurantOrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientInMenuItemController : Controller
    {
        private readonly IIngredientInMenuItemService _ingredientInMenuItemService;

        public IngredientInMenuItemController(IIngredientInMenuItemService ingredientInMenuItemService)
        {
            _ingredientInMenuItemService = ingredientInMenuItemService;
        }


        [HttpPost("addIngredientToMenuItem")]
        public async Task<IActionResult> addIngredientToMenuItem(IngredientInMenuItemAddRequest addRequest)
        {
            try
            {
                IngredientInMenuItemResponse addedIngredientToMenuItem = await _ingredientInMenuItemService.AddIngredientToMenuItem(addRequest);

                return Ok(new IngredientInMenuItemResponse
                {
                    IngredientInMenuItemId = addedIngredientToMenuItem.IngredientInMenuItemId,
                    IngredientId = addedIngredientToMenuItem.IngredientId,
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

        [HttpGet("getAllIngredientToMenuItem")]
        public async Task<IActionResult> getAllIngredientToMenuItem()
        {
            try
            {
                IEnumerable<IngredientInMenuItemResponse> allIngredientToMenuItem = await _ingredientInMenuItemService.GetAllIngredientInMenuItem();
                return Ok(allIngredientToMenuItem);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
    }
}
