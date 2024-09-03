using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.Enums;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
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
        public string IngredientName { get; set; }
        public double IngredientQuantity { get; set; }

        public string IngredientUnit {  get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as IngredientInMenuItemResponse;
            if (other == null)
                return false;

            return this.IngredientInMenuItemId == other.IngredientInMenuItemId &&
                   this.MenuItemId == other.MenuItemId &&
                   this.IngredientId == other.IngredientId &&
                   this.IngredientName == other.IngredientName &&
                   this.IngredientQuantity == other.IngredientQuantity &&
                   this.IngredientUnit == other.IngredientUnit;
        }
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
