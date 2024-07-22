using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientInMenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Services
{
    public class IngredientInMenuItemService : IIngredientInMenuItemService
    {
        private readonly ManagerDbContext _dbContext;
        private readonly IMenuItemService _menuItemService;
        private readonly IIngredientService _ingredientService;

        public IngredientInMenuItemService(ManagerDbContext dbContext, IMenuItemService menuItemService, IIngredientService ingredientService)
        {
            _dbContext = dbContext;
            _menuItemService = menuItemService;
            _ingredientService = ingredientService;
        }
        public async Task<IEnumerable<IngredientInMenuItemResponse>> GetAllIngredientInMenuItem()
        {
            return await _dbContext.IngredientsInMenuItem.Select(ingredInMenuItem => ingredInMenuItem.ToIngredientInMenuItemResponse()).ToListAsync(); 

        }

        public async Task<bool> GetIngredientInMenuItemByIds(IngredientInMenuItemAddRequest searchRequest)
        {
            bool findIngredient = await _dbContext.IngredientsInMenuItem.AnyAsync(ing => ing.IngredientId == searchRequest.IngredientId
                                                                                       && ing.MenuItemId == searchRequest.MenuItemId);

            return findIngredient;
        }



        public async Task<IngredientInMenuItemResponse> AddIngredientToMenuItem(IngredientInMenuItemAddRequest addRequest)
        {
            if( addRequest == null)
            {
                throw new ArgumentNullException(nameof(addRequest));
            }

            //check if ingredient doesn't belong to that menuItem
            if (await GetIngredientInMenuItemByIds(addRequest))
            {
                throw new ArgumentException($"This Ingredient - {addRequest.IngredientId} already exist in MenuItem");
            }

            //check if ingredient exist
            if(_ingredientService.FindIngredientById(addRequest.IngredientId) != null)
            {
                throw new ArgumentException($"Ingredient with id - {addRequest.IngredientId} doesn't exist");
            }



            //check if menuItem exist
            if(_menuItemService.FindMenuItemById(addRequest.MenuItemId) != null)
            {
                throw new ArgumentException($"MenuItem with id - {addRequest.MenuItemId} doesn't exist");
            } 



            IngredientInMenuItem ingredientInMenuItem = addRequest.ToIngredientInMenuItem();

            _dbContext.Add(ingredientInMenuItem);
            await _dbContext.SaveChangesAsync();

            return ingredientInMenuItem.ToIngredientInMenuItemResponse();
        }


    }
}
