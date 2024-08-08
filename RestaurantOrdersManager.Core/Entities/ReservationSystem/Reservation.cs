using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Entities.ReservationSystem
{
    public class Reservation
    {
        public int ReservationId { get; set; }  
        public string ReservationInfo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? TableId { get; set; }
        public Table Table { get; set; }
    }
}
