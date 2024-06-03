using RestaurantOrdersManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO
{
    public class MenuItemAddRequest
    {
        [Required(ErrorMessage = "Please provide name of menu item")]
        public string? ItemName { get; set; }
        public Enum? ItemStatus { get; set; }

        public MenuItem ToMenuItem()
        {
            return new MenuItem() { ItemName = ItemName };
        }
    }
}
