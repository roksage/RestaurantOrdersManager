using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersDTO.CookingStationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices
{
    public interface ICookingStationService
    {
        Task<IEnumerable<CookingStationResponse>> GetAllCookingStation();
        Task<IEnumerable<MenuItemToOrderResponse>> GetItemsInCookingStation(int cookingStationId);   
    }
}
