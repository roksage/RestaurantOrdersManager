using RestaurantOrdersManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeFinished { get; set; }
        public ICollection<OrderedMenuItem>? OrderMenuItems { get; set; }
    }
    public static class OrderResponseExtension
    {
        public static OrderResponse ToOrderResponse(this Order response)
        {
            return new OrderResponse { 
                OrderId = response.OrderId,
                CreatedBy = response.CreatedBy,
                TimeCreated = response.TimeCreated,
                TimeFinished = response.TimeFinished,
                OrderMenuItems = response.OrderMenuItems.ToList()
            };

        }
    }
}
