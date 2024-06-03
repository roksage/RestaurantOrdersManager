using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrdersManager.Core.Entities
{
    public class Order
    {
        [Key]
        public int OrderId {  get; set; }
        [Required(ErrorMessage ="Please provide person who's creating the order Id")]
        public int CreatedBy { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeFinished { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();    
        public Order()
        {
            TimeCreated = DateTime.Now;
        }
    }
}
