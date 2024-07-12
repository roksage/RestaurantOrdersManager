using System.ComponentModel.DataAnnotations;

namespace RestaurantOrdersManager.Core.Entities
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

        public MenuItemToOrder()
        {
            ProcessStarted = DateTime.Now;
        }
    }
}
