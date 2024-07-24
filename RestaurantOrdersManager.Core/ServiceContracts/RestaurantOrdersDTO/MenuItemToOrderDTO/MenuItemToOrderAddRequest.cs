using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using System.ComponentModel.DataAnnotations;


namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItem
{
    public class MenuItemToOrderAddRequest
    {
        [Required(ErrorMessage = "Please provide OrderId")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please provide MenuItemId")]
        public int MenuItemId { get; set; }

        public DateTime ProcessStarted { get; set; }

        public MenuItemToOrder ToMenuItemToOrderAddRequest()
        {
            return new MenuItemToOrder { OrderId = OrderId, MenuItemId = MenuItemId};
        }

    }
}
