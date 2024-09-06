using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Entities.RestaurantOrders
{
    public class OrderProgress
    {
        public int OrderId { get; set; }
        public decimal ProgressPercentage { get; set; }
    }
}
