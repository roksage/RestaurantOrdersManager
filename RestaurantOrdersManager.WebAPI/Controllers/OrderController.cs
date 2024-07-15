using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using RestaurantOrdersManager.Core.Services;
using System.ComponentModel.DataAnnotations;


namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService OrderService)
        {
            _orderService = OrderService;
        }

        [HttpPost("createOrder")]
        public async Task<IActionResult> createOrder(OrderCreateRequest createOrderRequest)
        {
            try
            {
                //check if employee that created order exists
                

                OrderResponse createOrder = await _orderService.createOrder(createOrderRequest);
                return Ok(new OrderResponse { OrderId = createOrder.OrderId, CreatedBy = createOrder.CreatedBy, TimeCreated = createOrder.TimeCreated });
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
                List<OrderResponse> allOrders = (await _orderService.GetAllOrders()).ToList();
                return Ok(allOrders);
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
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
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
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

    }
}