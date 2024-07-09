using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO
{
    public class MenuItemResponse
    {
        public int MenuItemId { get; set; }
        public string? ItemName { get; set; }
        public StatusEnums ItemStatus { get; set; }
    }
    public static class MenuItemResponseExtension
    {
        public static MenuItemResponse MenuItemResponse(this MenuItem menuItem)
        {
            return new MenuItemResponse() { MenuItemId = menuItem.MenuItemId, ItemName = menuItem.ItemName, ItemStatus = menuItem.ItemStatus };
        }
    }
}
