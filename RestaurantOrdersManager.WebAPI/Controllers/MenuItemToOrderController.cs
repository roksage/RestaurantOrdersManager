using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
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

        [HttpGet("getAllOrders")]
        public async Task<IActionResult> GetAllOrder()
        {

            try
            {
                List<MenuItemToOrderResponse> allMenuItemsInOrder = await _menuItemToOrderServiceService.GetAllMenuItemToOrderService();
                return Ok(allMenuItemsInOrder);
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