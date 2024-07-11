using System.ComponentModel.DataAnnotations;

namespace RestaurantOrdersManager.Core.Entities
{
    public class OrderedMenuItem
    {
        [Key]
        public int OrderedMenuItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public DateTime ProcessStarted { get; set; }
        public DateTime? ProcessCompleted { get; set; }

        public OrderedMenuItem()
        {
            ProcessStarted = DateTime.Now;
        }
    }
}
