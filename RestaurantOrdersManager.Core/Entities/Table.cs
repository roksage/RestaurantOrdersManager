using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Entities
{
    public class Table
    {
        [Key]   
        public int TableId { get; set; }
        public string TableName { get; set; }
        public int Seats { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
