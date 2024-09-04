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
using RestaurantOrdersManager.Core.Services.RestaurantOrdersServices;
using RestaurantOrdersManager.WebAPI.Helpers;
using System.ComponentModel.DataAnnotations;


namespace RestaurantOrdersManager.WebAPI.Controllers.RestaurantOrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemToOrderController : ControllerBase
    {
        private readonly IMenuItemToOrderService _menuItemToOrderService;
        private readonly IHubContext<CookingStationsHub> _cookingStationsHubSignalR;
        private readonly ICookingStationService _cookingStationService;


        public MenuItemToOrderController(IMenuItemToOrderService MenuItemToOrderService, IHubContext<CookingStationsHub> CookingStationsHubSignalR, ICookingStationService CookingStationService)
        {
            _menuItemToOrderService = MenuItemToOrderService;
            _cookingStationsHubSignalR = CookingStationsHubSignalR;
            _cookingStationService =CookingStationService;
        }

        private async Task NotifyWorkStations()
        {
            await _cookingStationsHubSignalR.Clients.All.SendAsync("SendToWorkStations", await _cookingStationService.GetItemsInCookingStation(1));
        }

        [HttpPost("addMenuItemToOrder")]
        public async Task<IActionResult> addMenuItemToOrder(MenuItemToOrderAddRequest MenuItemAddRequestRequest)
        {
            try
            {
                MenuItemToOrderResponse createOrder = await _menuItemToOrderService.MenuItemToOrderServiceAddRequest(MenuItemAddRequestRequest);
                await NotifyWorkStations();
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
                IEnumerable<MenuItemToOrderResponse> allOrderedMenuItems = await _menuItemToOrderService.GetAllMenuItemToOrderService();
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
                MenuItemToOrderResponse completeMenuItemInOrder = await _menuItemToOrderService.CompleteMenuItemInOrder(OrderedMenuItemId);
                await NotifyWorkStations();
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