using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO
{
    public class IngredientInMenuItemResponse
    {
        public int IngredientInMenuItemId { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public IngredientEnums IngredientUnit { get; set; }
        public double IngredientAmount { get; set; }
    }

    public static class IngredientInMenuItemResponseExtension
    {
        public static IngredientInMenuItemResponse ToIngredientInMenuItemResponse(this IngredientInMenuItem ingredientInMenuItem)
        {
            return new IngredientInMenuItemResponse
            {
                IngredientInMenuItemId = ingredientInMenuItem.IngredientInMenuItemId,
                IngredientId = ingredientInMenuItem.IngredientId,
                IngredientName = ingredientInMenuItem.Ingredient.IngredientName,
                IngredientUnit = ingredientInMenuItem.Ingredient.IngredientUnit,
                IngredientAmount = ingredientInMenuItem.Ingredient.IngredientAmount
            };
        }
    }
}
