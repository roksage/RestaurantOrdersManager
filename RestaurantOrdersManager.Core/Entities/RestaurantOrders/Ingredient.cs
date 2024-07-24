using RestaurantOrdersManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Entities.RestaurantOrders
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }

        public IngredientEnums IngredientUnit { get; set; }
        public double IngredientAmount { get; set; }

        public ICollection<IngredientInMenuItem> IngredientsInMenuItems { get; set; } = new List<IngredientInMenuItem>();
    }
}
