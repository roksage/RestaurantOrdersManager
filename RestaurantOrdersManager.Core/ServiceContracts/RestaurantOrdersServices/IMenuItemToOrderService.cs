using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemToOrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItem;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices
{
    public interface IMenuItemToOrderService
    {
        Task<MenuItemToOrderResponse> MenuItemToOrderServiceAddRequest(MenuItemToOrderAddRequest addRequest);
        Task<IEnumerable<MenuItemToOrderResponse>> GetAllMenuItemToOrderService();
        Task<MenuItemToOrderResponse> CompleteMenuItemInOrder(MenuItemToOrderCompleteMenuItemById OrderedMenuItemId);
    }
}
