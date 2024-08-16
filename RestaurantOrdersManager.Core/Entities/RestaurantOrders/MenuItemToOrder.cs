using System.ComponentModel.DataAnnotations;

namespace RestaurantOrdersManager.Core.Entities.RestaurantOrders
{
    public class MenuItemToOrder
    {
        [Key]
        public int OrderedMenuItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public DateTime ProcessStarted { get; set; }
        public DateTime? ProcessCompleted { get; set; }
        public int CookingStationId { get; set; }
        public CookingStation CookingStation { get; set; }

        public MenuItemToOrder()
        {
            ProcessStarted = DateTime.Now;
        }
    }
}
