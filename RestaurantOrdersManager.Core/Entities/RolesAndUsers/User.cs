﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Entities.RolesAndUsers
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } 
    }
}
