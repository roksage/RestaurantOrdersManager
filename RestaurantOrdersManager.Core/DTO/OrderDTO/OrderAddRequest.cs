using RestaurantOrdersManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.DTO.OrderDTO
{
    public class OrderAddRequest
    {
        [Required(ErrorMessage ="provide creadetby")]
        public int CreatedBy { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeFinished { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public required Enum OrderStatus { get; set; }

        public Order ToOrder()
        {
            return new Order { CreatedBy = CreatedBy, TimeCreated = TimeCreated, OrderStatus = OrderStatus };
        }
    }
}
