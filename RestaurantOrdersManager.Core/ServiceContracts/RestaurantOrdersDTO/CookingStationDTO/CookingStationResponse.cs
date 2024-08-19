using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersDTO.CookingStationDTO
{
    public class CookingStationResponse
    {
        public int cookingStationId { get; set; }
        public string cookingStationName { get; set; }
        public ICollection<MenuItemToOrderResponse> cookingStationOrders { get; set; }
    }
    public static class CookingStationResponseExtention
    {
        public static CookingStationResponse ToCookingStationResponse(this CookingStation request)
        {
            return new CookingStationResponse
            {
                cookingStationId = request.cookingStationId,
                cookingStationName = request.cookingStationName,
                cookingStationOrders = request.cookingStationOrders.Select(i => i.ToOrderedMenuItemResponse()).ToList()
            };
        }
    }
}
