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
        private readonly RestaurantOrdersDbContext _dbContext;
        public CookingStationService(RestaurantOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<CookingStationResponse>> GetAllCookingStations()
        {
            IEnumerable<CookingStationResponse> allCookingStations = await _dbContext.CookingStations.Select(t => t.ToCookingStationResponse()).ToListAsync();
            return allCookingStations;
        }

        public async Task<IEnumerable<MenuItemResponse>> GetItemsInCookingStation(int cookingStationId)
        {
            var result = await _dbContext.CookingStations
                                         .Where(cs => cs.cookingStationId == cookingStationId)
                                         .SelectMany(cs => cs.cookingStationOrders)
                                         .Select(order => new MenuItemResponse
                                         {
                                             ItemName = order.MenuItem.ItemName,
                                             MenuItemId = order.MenuItem.MenuItemId,    
                                             IngredientsInMenuItem = order.MenuItem.IngredientsInMenuItem
                                                                       .Select(ingredientInMenuItem => new IngredientInMenuItemResponse
                                                                       {
                                                                           IngredientId = ingredientInMenuItem.Ingredient.IngredientId,
                                                                           IngredientInMenuItemId = ingredientInMenuItem.IngredientInMenuItemId,
                                                                           MenuItemId = ingredientInMenuItem.MenuItemId,
                                                                           IngredientName = ingredientInMenuItem.Ingredient.IngredientName,
                                                                           IngredientQuantity = ingredientInMenuItem.Ingredient.IngredientAmount,
                                                                           IngredientUnit = ingredientInMenuItem.Ingredient.IngredientUnit.ToString(),
                                                                       })
                                                                       .ToList(),
                                         })
                                         .ToListAsync();
            return result;
        }
    }
}
