using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO
{
    public class OrderCreateRequest
    {
        [Required(ErrorMessage = "please provide employee id")]
        public int CreatedBy { get; set; }

        public int TableId { get; set; }

        public Order ToOrder()
        {
            return new Order { CreatedBy = CreatedBy, TableId = TableId };
        }
    }
}
