using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemToOrderDTO
{
    public class MenuItemToOrderCompleteMenuItemById
    {
        [Required(ErrorMessage = "Please provide MenuItemToOrder OrderedMenuItemId")]

        public int OrderedMenuItemId { get; set; }
    } 
}
