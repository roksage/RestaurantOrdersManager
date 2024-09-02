using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersDTO.CookingStationDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Services.RestaurantOrdersServices
{
    public class CookingStationService : ICookingStationService
    {
        private readonly ICookingStationService _cookingStationService;
        private readonly RestaurantOrdersDbContext _dbContext;
        public CookingStationService(RestaurantOrdersDbContext dbContext, ICookingStationService cookingStationService)
        {
            _cookingStationService = cookingStationService;
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<CookingStationResponse>> GetAllCookingStation()
        {
            IEnumerable<CookingStationResponse> allCookingStations = await _dbContext.CookingStations.Select(t => t.ToCookingStationResponse()).ToListAsync();
            return allCookingStations;
        }

        public async Task<IEnumerable<MenuItemToOrderResponse>> GetItemsInCookingStation(int cookingStationId)
        {
            var result = await _dbContext.CookingStations.Where(cs => cs.cookingStationId == cookingStationId)
                                 .Include(cs => cs.cookingStationOrders)
                                 .ThenInclude(order => order.MenuItem)
                                 .ThenInclude(menuItem => menuItem.OrderMenuItems)
                                 .Select(cs => new MenuItemToOrderResponse
                                 {
                                     // Populate the MenuItemToOrderResponse properties here
                                     MenuItemId = cs.cookingStationOrders.MenuItem.MenuItemId,
                                     MenuItemName = cs.cookingStationOrders.MenuItem.Name,
                                     Quantity = cs.cookingStationOrders.OrderMenuItems.Count,
                                     // Add other necessary properties
                                 })
                                 .ToListAsync();
            return result;
        }
    }
}
