using RestaurantOrdersManager.Core.Enums;
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
        [Required]
        [StringLength(50)]
        public string TableName { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Seats { get; set; }

        public TableStatus Status { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
