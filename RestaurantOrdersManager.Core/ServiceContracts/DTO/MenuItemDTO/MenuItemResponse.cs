using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.Enums;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientInMenuItemDTO;


namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO
{
    public class MenuItemResponse
    {
        public int MenuItemId { get; set; }
        public string? ItemName { get; set; }

        public ICollection<IngredientInMenuItemResponse> IngredientsInMenuItem { get; set; }

    }
    public static class MenuItemResponseExtension
    {
        public static MenuItemResponse MenuItemResponse(this MenuItem menuItem)
        {
            return new MenuItemResponse() { MenuItemId = menuItem.MenuItemId, 
                                            ItemName = menuItem.ItemName,
                                            IngredientsInMenuItem = menuItem.Ingredients.Select(omi => omi.ToIngredientInMenuItemResponse()).ToList(),
            };
        }
    }
}
