using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;


using RestaurantOrdersManager.Infrastructure;
using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;

namespace RestaurantOrdersManager.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ManagerDbContext _dbContext;
        private readonly IEmployeeService _employeeService;

        public OrderService(ManagerDbContext dbContext, IEmployeeService employeeService)
        {
            _dbContext = dbContext;
            _employeeService = employeeService;
        }

        public async Task<OrderResponse> createOrder(OrderCreateRequest AddRequest)
        {
            if (AddRequest == null)
            {
                throw new ArgumentNullException(nameof(AddRequest));
            }

            EmployeeResponse employee = await _employeeService.GetEmployeeById(AddRequest.CreatedBy);

            //check if employee exists
            if (employee == null)
            {
                throw new Exception($"Employee with id {AddRequest.CreatedBy} not found.");
            }

            Order order = AddRequest.ToOrder();
            _dbContext.Add(order);
            await _dbContext.SaveChangesAsync();
            return order.ToOrderResponse();
        }

        public async Task<IEnumerable<MenuItemToOrderResponse>> GetAllMenuItemsInOrder(int? OrderId)
        {
            if (OrderId == null)
            {
                throw new ArgumentNullException(nameof(OrderId));
            }

            Order? order = await _dbContext.Orders.Include(o => o.OrderMenuItems)
                                         .ThenInclude(omi => omi.MenuItem)
                                         .FirstOrDefaultAsync(o => o.OrderId == OrderId);

            if (order == null)
            {
                throw new Exception($"Order with id {OrderId} not found.");
            }

            return order.OrderMenuItems.ToOrderedMenuItemResponse();
        }


        public async Task<IEnumerable<OrderResponse>> GetAllOrders()
        {
            return await _dbContext.Orders
                .Include(o => o.OrderMenuItems)
                .ThenInclude(omi => omi.MenuItem)
                .Select(order => order.ToOrderResponse())
                .ToListAsync();
        }



        public async Task<bool> CheckIfOrderIsCompleted(int OrderId)
        {
            IEnumerable<MenuItemToOrderResponse> getAllItemsInOrder = await GetAllMenuItemsInOrder(OrderId);

            foreach (var item in getAllItemsInOrder)
            {
                if (item.ProcessCompleted == null)
                {
                    return false;
                }
            }

            Order order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == OrderId);

            if(order == null)
            {
                return false;
            }

            order.TimeFinished = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<OrderResponse>> GetAllActiveOrders()
        {
            return await _dbContext.Orders
                .Include(o => o.OrderMenuItems)
                .ThenInclude(omi => omi.MenuItem)
                .Where(of => of.TimeFinished == null)
                .Select(order => order.ToOrderResponse())
                .ToListAsync();
        }
    }
}
