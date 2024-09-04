using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.Enums;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientInMenuItemDTO;


namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO
{
    public class MenuItemResponse
    {
        public int MenuItemId { get; set; }
        public string? ItemName { get; set; }
        public int CookingStationId { get; set; }

        public ICollection<IngredientInMenuItemResponse>? IngredientsInMenuItem { get; set; }

    }
    public static class MenuItemResponseExtension
    {
        public static MenuItemResponse ToMenuItemResponse(this MenuItem menuItem)
        {
            return new MenuItemResponse { MenuItemId = menuItem.MenuItemId, 
                                            ItemName = menuItem.ItemName,
                                            CookingStationId = menuItem.CookingStationId,
                                            IngredientsInMenuItem = menuItem.IngredientsInMenuItem.Select(i => i.ToIngredientInMenuItemResponse()).ToList(),
            };
        }
    }
}
