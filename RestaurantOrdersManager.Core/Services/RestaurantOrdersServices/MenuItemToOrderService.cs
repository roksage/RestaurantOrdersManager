
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItem;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using RestaurantOrdersManager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemToOrderDTO;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using Microsoft.AspNetCore.SignalR;

namespace RestaurantOrdersManager.Core.Services.RestaurantOrdersServices
{
    public class MenuItemToOrderService : IMenuItemToOrderService
    {
        private readonly RestaurantOrdersDbContext _dbContext;
        private readonly IOrderService _orderService;


        public MenuItemToOrderService(RestaurantOrdersDbContext dbContext, IOrderService orderService)
        {
            _dbContext = dbContext;
            _orderService = orderService;
        }


        public async Task<MenuItemToOrderResponse> CompleteMenuItemInOrder(MenuItemToOrderCompleteMenuItemById OrderedMenuItemId)
        {
            if (OrderedMenuItemId == null)
            {
                throw new ArgumentNullException(nameof(OrderedMenuItemId));
            }
            // find item by id

            MenuItemToOrder? orderedMenuItem = await _dbContext.OrderMenuItems.FirstOrDefaultAsync(x => x.OrderedMenuItemId == OrderedMenuItemId.OrderedMenuItemId);


            if (orderedMenuItem == null)
            {
                throw new KeyNotFoundException("Ordered menu item not found.");
            }

            if (orderedMenuItem.ProcessCompleted != null)
            {
                throw new InvalidOperationException("Ordered menu item is already completed.");
            }

            orderedMenuItem.ProcessCompleted = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            //check if order is completed

            bool isOrderCompleted = await _orderService.CheckIfOrderIsCompleted(orderedMenuItem.OrderId);

            return orderedMenuItem.ToOrderedMenuItemResponse();

        }

        public async Task<IEnumerable<MenuItemToOrderResponse>> GetAllMenuItemToOrderService()
        {
            return await _dbContext.OrderMenuItems.Select(OrderedMenuItem => OrderedMenuItem.ToOrderedMenuItemResponse()).ToListAsync();
        }

        public async Task<MenuItemToOrderResponse> MenuItemToOrderServiceAddRequest(MenuItemToOrderAddRequest addRequest)
        {
            if (addRequest == null)
            {
                throw new ArgumentNullException(nameof(addRequest));
            }

            MenuItem menuItem = await _dbContext.MenuItems.FirstOrDefaultAsync(mi => mi.MenuItemId == addRequest.MenuItemId);

            if (menuItem == null)
            {
                throw new ArgumentException("Invalid MenuItemId: MenuItem does not exist.");
            }

            // Check if OrderId exists in the Orders table
            var orderExists = await _dbContext.Orders.AnyAsync(o => o.OrderId == addRequest.OrderId);
            if (!orderExists)
            {
                throw new ArgumentException("Invalid OrderId: Order does not exist.");
            }



            // Map the addRequest to the entity 
            MenuItemToOrder orderedMenuItem = addRequest.ToMenuItemToOrderAddRequest();


            //find menu item cooking station
            orderedMenuItem.CookingStationId = menuItem.CookingStationId;

            // Add and save the entity
            _dbContext.Add(orderedMenuItem);
            await _dbContext.SaveChangesAsync();

            // Map the entity to the response and return
            return orderedMenuItem.ToOrderedMenuItemResponse();
        }



    }
}
