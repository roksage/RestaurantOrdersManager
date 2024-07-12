
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItem;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using RestaurantOrdersManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrdersManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace RestaurantOrdersManager.Core.ServiceContracts
{
    public class MenuItemToOrderService : IMenuItemToOrderService
    {
        private readonly ManagerDbContext _dbContext;

        public MenuItemToOrderService(ManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MenuItemToOrderResponse>> GetAllMenuItemToOrderService()
        {
            return await _dbContext.OrderMenuItems.Select(OrderedMenuItem => OrderedMenuItem.ToOrderedMenuItemResponse()).ToListAsync();
        }

        public async Task<MenuItemToOrderResponse> MenuItemToOrderServiceAddRequest(MenuItemToOrderAddRequest addRequest)
        {
            if (addRequest == null)
            {
                throw new ArgumentNullException(nameof(addRequest));
            }

            // Check if MenuItemId exists in the MenuItems table
            var menuItemExists = await _dbContext.MenuItems.AnyAsync(mi => mi.MenuItemId == addRequest.MenuItemId);
            if (!menuItemExists)
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
            Entities.MenuItemToOrder orderedMenuItem = addRequest.ToMenuItemToOrderAddRequest();

            // Add and save the entity
            _dbContext.Add(orderedMenuItem);
            await _dbContext.SaveChangesAsync();

            // Map the entity to the response and return
            return orderedMenuItem.ToOrderedMenuItemResponse();
        }



    }
}
