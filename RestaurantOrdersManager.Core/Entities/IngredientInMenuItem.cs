using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Entities
{
    public class IngredientInMenuItem
    {
        [Key] 
        public int IngredientInMenuItemId { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }

    }
}
