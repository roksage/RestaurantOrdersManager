using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Identity.Client;
using NuGet.Common;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemToOrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItem;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Core.Services;
using RestaurantOrdersManager.WebAPI.Helpers;
using System.ComponentModel.DataAnnotations;


namespace RestaurantOrdersManager.WebAPI.Controllers.RestaurantOrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemToOrderController : ControllerBase
    {
        private readonly IMenuItemToOrderService _menuItemToOrderServiceService;
        private readonly IHubContext<CookingStationsHub> _cookingStationsHubSignalR;
        private readonly ICookingStationService _cookingStationService;


        public MenuItemToOrderController(IMenuItemToOrderService MenuItemToOrderService, IHubContext<CookingStationsHub> cookingStationsHubSignalR, ICookingStationService cookingStationService)
        {
            _menuItemToOrderServiceService = MenuItemToOrderService;
            _cookingStationsHubSignalR = cookingStationsHubSignalR;
            _cookingStationService = cookingStationService;
        }

        [HttpPost("addMenuItemToOrder")]
        public async Task<IActionResult> addMenuItemToOrder(MenuItemToOrderAddRequest MenuItemAddRequestRequest)
        {
            try
            {
                MenuItemToOrderResponse createOrder = await _menuItemToOrderServiceService.MenuItemToOrderServiceAddRequest(MenuItemAddRequestRequest);
                await _cookingStationsHubSignalR.Clients.All.SendAsync("SendToWorkStations", await _cookingStationService.GetItemsInCookingStation(1));
                return Ok(new MenuItemToOrderResponse { CookingStationId = createOrder.CookingStationId });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
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
                return BadRequest(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpPut("completeMenuItemInOrder")]
        public async Task<IActionResult> completeMenuItemInOrder(MenuItemToOrderCompleteMenuItemById OrderedMenuItemId)
        {
            try
            {
                MenuItemToOrderResponse completeMenuItemInOrder = await _menuItemToOrderServiceService.CompleteMenuItemInOrder(OrderedMenuItemId);
                await _cookingStationsHubSignalR.Clients.All.SendAsync("SendToWorkStations", await _cookingStationService.GetItemsInCookingStation(1));
                return Ok(completeMenuItemInOrder);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { ex.Message });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
    }
}