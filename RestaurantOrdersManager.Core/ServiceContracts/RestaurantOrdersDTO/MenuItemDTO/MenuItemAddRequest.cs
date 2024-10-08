﻿using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO
{
    public class MenuItemAddRequest
    {
        [Required(ErrorMessage = "Please provide name of menu item")]
        public string? ItemName { get; set; }
        public int CookingStationId { get; set; }

        public MenuItem ToMenuItem()
        {
            return new MenuItem() { ItemName = ItemName, CookingStationId = CookingStationId };
        }
    }
}
