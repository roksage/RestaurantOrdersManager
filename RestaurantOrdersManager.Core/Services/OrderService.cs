using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;


using RestaurantOrdersManager.Infrastructure;
using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;

namespace RestaurantOrdersManager.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ManagerDbContext _dbContext;

        public OrderService(ManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderResponse> createOrder(OrderAddRequest AddRequest)
        {
            if (AddRequest == null)
            {
                throw new ArgumentNullException(nameof(AddRequest));
            }
            Order order = AddRequest.ToOrder();
            _dbContext.Add(order);
            await _dbContext.SaveChangesAsync();
            return order.ToOrderResponse();
        }

        public async Task<List<OrderResponse>> GetAllOrders()
        {
            return await _dbContext.Orders.Select(Orders => Orders.ToOrderResponse()).ToListAsync();
        }

    }
}
