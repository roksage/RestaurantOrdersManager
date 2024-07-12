﻿using RestaurantOrdersManager.Core.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrdersManager.Core.Entities
{
    public class Order
    {
        [Key]
        public int OrderId {  get; set; }
        public int CreatedBy { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeFinished { get; set; }
        public ICollection<MenuItemToOrder> OrderMenuItems { get; set; } = new List<MenuItemToOrder>();
        public Order()
        {
            TimeCreated = DateTime.Now;
        }
    }
}
