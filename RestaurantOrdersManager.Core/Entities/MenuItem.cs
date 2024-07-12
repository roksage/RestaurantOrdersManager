using RestaurantOrdersManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Entities
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }
        public string? ItemName {  get; set; }
        public ICollection<MenuItemToOrder> OrderMenuItems { get; set; } = new List<MenuItemToOrder>();
    }
}
