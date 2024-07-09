using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;


using RestaurantOrdersManager.Infrastructure;
using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;


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
    }
}
