using RestaurantOrdersManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrdersManager.Core.Entities.ReservationSystem;

namespace RestaurantOrdersManager.Core.Entities.RestaurantOrders
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }
        [StringLength(50)]
        public string TableName { get; set; }
        [Range(0, int.MaxValue)]
        public int Seats { get; set; }

        public TableStatusEnums Status { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        public Table()
        {
            Status = TableStatusEnums.Free;
        }
    }
}
