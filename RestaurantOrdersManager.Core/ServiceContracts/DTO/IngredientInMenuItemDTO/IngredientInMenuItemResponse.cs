using RestaurantOrdersManager.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientInMenuItemDTO
{
    public class IngredientInMenuItemResponse
    {
        public int IngredientInMenuItemId { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }

    public static class IngredientInMenuItemResponseExtension
    {
        public static IngredientInMenuItemResponse ToIngredientInMenuItemResponse(this IngredientInMenuItem ingredient)
        {
            return new IngredientInMenuItemResponse
            {
                IngredientInMenuItemId = ingredient.IngredientInMenuItemId,
                IngredientId = ingredient.IngredientId,
                MenuItemId = ingredient.MenuItemId
            };
        }
    }
}
