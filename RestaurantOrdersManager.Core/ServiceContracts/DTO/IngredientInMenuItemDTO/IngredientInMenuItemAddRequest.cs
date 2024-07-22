using RestaurantOrdersManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientInMenuItemDTO
{
    public class IngredientInMenuItemAddRequest
    {

        [Required]
        public int IngredientId { get; set; }
        [Required]
        public int MenuItemId { get; set; }

        public IngredientInMenuItem ToIngredientInMenuItem()
        {
            return new IngredientInMenuItem { IngredientId = IngredientId, MenuItemId = MenuItemId };
        }
    }
}
