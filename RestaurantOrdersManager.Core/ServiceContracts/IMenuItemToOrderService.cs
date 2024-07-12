using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItem;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts
{
    public interface IMenuItemToOrderService
    {
        Task<MenuItemToOrderResponse> MenuItemToOrderServiceAddRequest(MenuItemToOrderAddRequest addRequest);
        Task<List<MenuItemToOrderResponse>> GetAllMenuItemToOrderService();
    }
}
