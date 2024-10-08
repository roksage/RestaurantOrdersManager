﻿using RestaurantOrdersManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Entities.RestaurantOrders
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }
        public string ItemName { get; set; }
        public int CookingStationId {  get; set; }
        public ICollection<IngredientInMenuItem> IngredientsInMenuItem { get; set; } = new List<IngredientInMenuItem>();
        public ICollection<MenuItemToOrder> OrderMenuItems { get; set; } = new List<MenuItemToOrder>();
    }
}
