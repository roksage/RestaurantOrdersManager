using RestaurantOrdersManager.Core.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrdersManager.Core.Entities
{
    public class Order
    {
        [Key]
        public int OrderId {  get; set; }
        public int CreatedBy { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeFinished { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();    
        public StatusEnums OrderStatus { get; set; }
        public Order()
        {
            TimeCreated = DateTime.Now;
            OrderStatus = StatusEnums.Received;
        }
    }
}
