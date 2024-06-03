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
        [Required(ErrorMessage ="Please provide menu item name")]
        public string? ItemName {  get; set; }
    }
}
