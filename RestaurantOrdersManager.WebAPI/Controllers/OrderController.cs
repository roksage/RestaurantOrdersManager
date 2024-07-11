using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;
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
        public async Task<IActionResult> createOrder(OrderAddRequest createOrderRequest)
        {
            try
            {
                OrderResponse createOrder = await _orderService.createOrder(createOrderRequest);
                return Ok(new OrderResponse { OrderId = createOrder.OrderId, CreatedBy = createOrder.CreatedBy, TimeCreated = createOrder.TimeCreated});
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
                List<OrderResponse> allOrders = await _orderService.GetAllOrders();
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
    }
}