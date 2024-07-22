using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts
{
    public interface IMenuItemService
    {
        Task<MenuItemResponse> AddMenuItem(MenuItemAddRequest AddRequest);  

        Task<List<MenuItemResponse>> GetAllMenuItems();

        Task<MenuItemResponse> FindMenuItemById(int menuItemId);
    }
}
