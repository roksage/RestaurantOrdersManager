using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Core.Services;
using RestaurantOrdersManager.WebAPI.Helpers;
using System.ComponentModel.DataAnnotations;


namespace RestaurantOrdersManager.WebAPI.Controllers.RestaurantOrdersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IHubContext<OrdersHub> _ordersHubSignalR;

        public OrderController(IOrderService OrderService, IHubContext<OrdersHub> ordersHubSignalR)
        {
            _orderService = OrderService;
            _ordersHubSignalR = ordersHubSignalR;
        }

        [HttpPost("createOrder")]
        public async Task<IActionResult> createOrder(OrderCreateRequest createOrderRequest)
        {
            try
            {
                //check if employee that created order exists


                OrderResponse createOrder = await _orderService.createOrder(createOrderRequest);

                List<OrderResponse> allOrders = (await _orderService.GetAllOrders()).ToList();
                await _ordersHubSignalR.Clients.All.SendAsync("SendToWorkStations ", allOrders);

                return Ok(new OrderResponse { OrderId = createOrder.OrderId, CreatedBy = createOrder.CreatedBy, TimeCreated = createOrder.TimeCreated });

               
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }


        [HttpGet("getAllOrders")]
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {
                List<OrderResponse> allOrders = (await _orderService.GetAllOrders()).ToList();
                return Ok(allOrders);
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


        [HttpGet("getAllMenuItemsInOrder/{orderId}")]
        public async Task<IActionResult> GetAllMenuItemsInOrder(int orderId)
        {
            try
            {
                IEnumerable<MenuItemToOrderResponse> menuItems = await _orderService.GetAllMenuItemsInOrder(orderId);
                return Ok(menuItems);
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

        [HttpGet("GetActiveOrders")]
        public async Task<IActionResult> GetActiveOrders()
        {
            try
            {
                IEnumerable<OrderResponse> activeOrders = await _orderService.GetAllActiveOrders();
                return Ok(activeOrders);
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
        [HttpGet("GetAllActiveOrdersWithCompletionStatus")]
        public async Task<IActionResult> GetAllActiveOrdersWithCompletionStatus()
        {
            try
            {
                IEnumerable<OrderProgress> activeOrdersWithProgress = await _orderService.GetAllActiveOrdersWithCompletionStatus();
                return Ok(activeOrdersWithProgress);
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