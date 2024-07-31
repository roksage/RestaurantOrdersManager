using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;


using RestaurantOrdersManager.Infrastructure;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;

namespace RestaurantOrdersManager.Core.Services.RestaurantOrdersServices
{
    public class MenuItemService : IMenuItemService
    {
        private readonly RestaurantOrdersDbContext _dbContext;

        public MenuItemService(RestaurantOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MenuItemResponse> AddMenuItem(MenuItemAddRequest AddRequest)
        {
            if (AddRequest == null)
            {
                throw new ArgumentNullException(nameof(AddRequest));
            }
            MenuItem menuItem = AddRequest.ToMenuItem();
            _dbContext.Add(menuItem);
            await _dbContext.SaveChangesAsync();
            return menuItem.ToMenuItemResponse();
        }

        public async Task<MenuItemResponse> FindMenuItemById(int menuItemId)
        {

            MenuItem? menuItem = await _dbContext.MenuItems.FindAsync(menuItemId);

            return menuItem?.ToMenuItemResponse();
        }

        public async Task<List<MenuItemResponse>> GetAllMenuItems()
        {
            return await _dbContext.MenuItems
                        .Include(o => o.IngredientsInMenuItem)
                        .ThenInclude(om => om.Ingredient)
                        .Select(menuItem => menuItem.ToMenuItemResponse())
                        .ToListAsync();
        }
    }
}
