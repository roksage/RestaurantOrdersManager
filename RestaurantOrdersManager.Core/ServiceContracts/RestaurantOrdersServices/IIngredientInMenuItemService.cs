using RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientInMenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemToOrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItem;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices
{
    public interface IIngredientInMenuItemService
    {


        Task<IngredientInMenuItemResponse> AddIngredientToMenuItem(IngredientInMenuItemAddRequest addRequest);
        Task<IEnumerable<IngredientInMenuItemResponse>> GetAllIngredientInMenuItem();

        Task<bool> GetIngredientInMenuItemByIds(IngredientInMenuItemAddRequest searchRequest);


    }
}
