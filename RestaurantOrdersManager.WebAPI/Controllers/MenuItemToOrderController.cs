using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemToOrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItem;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using RestaurantOrdersManager.Core.Services;
using System.ComponentModel.DataAnnotations;


namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemToOrderController : ControllerBase
    {
        private readonly IMenuItemToOrderService _menuItemToOrderServiceService;

        public MenuItemToOrderController(IMenuItemToOrderService MenuItemToOrderService)
        {
            _menuItemToOrderServiceService = MenuItemToOrderService;
        }

        [HttpPost("addMenuItemToOrder")]
        public async Task<IActionResult> addMenuItemToOrder(MenuItemToOrderAddRequest MenuItemAddRequestRequest)
        {
            try
            {
                MenuItemToOrderResponse createOrder = await _menuItemToOrderServiceService.MenuItemToOrderServiceAddRequest(MenuItemAddRequestRequest);
                return Ok(new MenuItemToOrderResponse { });
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

        [HttpGet("allOrderedMenuItems")]
        public async Task<IActionResult> allOrderedMenuItems()
        {

            try
            {
                IEnumerable<MenuItemToOrderResponse> allOrderedMenuItems = await _menuItemToOrderServiceService.GetAllMenuItemToOrderService();
                return Ok(allOrderedMenuItems);
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

        [HttpPost("completeMenuItemInOrder")]
        public async Task<IActionResult> completeMenuItemInOrder(MenuItemToOrderCompleteMenuItemById OrderedMenuItemId)
        {
            try
            {
                MenuItemToOrderResponse completeMenuItemInOrder = await _menuItemToOrderServiceService.CompleteMenuItemInOrder(OrderedMenuItemId);
                return Ok(completeMenuItemInOrder);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
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