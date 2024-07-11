﻿using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using System.ComponentModel.DataAnnotations;


namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpPost("addMenuItem")]
        public async Task<IActionResult> AddMenuItem(MenuItemAddRequest addMenuItemRequest)
        {
            try
            {
                MenuItemResponse addMenuItem = await _menuItemService.AddMenuItem(addMenuItemRequest);
                return Ok(new MenuItemResponse { MenuItemId = addMenuItem.MenuItemId, ItemName = addMenuItem.ItemName});
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("getAllMenuItems")]
        public async Task<IActionResult> GetAllMenuItems()
        {

            try
            {
                List<MenuItemResponse> allMenuItems = await _menuItemService.GetAllMenuItems();
                return Ok(allMenuItems);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}