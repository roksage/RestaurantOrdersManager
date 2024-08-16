using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Entities.RestaurantOrders
{
    public class CookingStation
    {
        public int cookingStationId {  get; set; }
        public string cookingStationName { get; set; }
        public ICollection<MenuItemToOrder> cookingStationOrders { get; set; }
    }
}
