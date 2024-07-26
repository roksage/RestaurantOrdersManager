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
        public int MenuItemId { get; set; }
    }

    public static class IngredientInMenuItemResponseExtension
    {
        public static IngredientInMenuItemResponse ToIngredientInMenuItemResponse(this IngredientInMenuItem ingredientInMenuItem)
        {
            return new IngredientInMenuItemResponse
            {
                IngredientInMenuItemId = ingredientInMenuItem.IngredientInMenuItemId,
                IngredientId = ingredientInMenuItem.IngredientId,
                MenuItemId = ingredientInMenuItem.MenuItemId,
            };
        }
    }
}
