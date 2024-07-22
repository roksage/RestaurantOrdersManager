using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;


using RestaurantOrdersManager.Infrastructure;
using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.ServiceContracts;

namespace RestaurantOrdersManager.Core.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly ManagerDbContext _dbContext;

        public MenuItemService(ManagerDbContext dbContext)
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
            return menuItem.MenuItemResponse();
        }

        public async Task<MenuItemResponse> FindMenuItemById(int menuItemId)
        {

            MenuItem? menuItem = await _dbContext.MenuItems.FirstOrDefaultAsync(MenuItem => MenuItem.MenuItemId == menuItemId);

            return menuItem.MenuItemResponse();
        }

        public async Task<List<MenuItemResponse>> GetAllMenuItems()
        {
            return await _dbContext.MenuItems.Select(MenuItems => MenuItems.MenuItemResponse()).ToListAsync();
        }
    }
}
