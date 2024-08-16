using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO
{
    public class MenuItemToOrderResponse
    {
        public int OrderedMenuItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public DateTime ProcessStarted { get; set; }
        public DateTime? ProcessCompleted { get; set; }
        public int CookingStationId { get; set; }
    }

    public static class OrderedMenuItemResponseExtension
    {
        public static MenuItemToOrderResponse ToOrderedMenuItemResponse(this MenuItemToOrder response)
        {
            return new MenuItemToOrderResponse
            {
                OrderedMenuItemId = response.OrderedMenuItemId,
                OrderId = response.OrderId,
                MenuItemId = response.MenuItemId,
                ProcessStarted = response.ProcessStarted,
                ProcessCompleted = response.ProcessCompleted,
                CookingStationId = response.CookingStationId
            };
        }
        public static IEnumerable<MenuItemToOrderResponse> ToOrderedMenuItemResponse(this ICollection<MenuItemToOrder> responses)
        {
            return responses.Select(response => response.ToOrderedMenuItemResponse()).ToList();
        }
    }
}
