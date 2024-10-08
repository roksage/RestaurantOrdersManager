﻿using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO
{
    public class EmployeeResponse
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as EmployeeResponse;
            if (other == null)
                return false;

            return this.EmployeeId == other.EmployeeId &&
                   this.LastName == other.LastName &&
                   this.Name == other.Name;
        }
    }
    public static class EmployeeResponseExtension
    {
        public static EmployeeResponse ToEmployeeResponse(this Employee employee)
        {
            return new EmployeeResponse { EmployeeId = employee.EmployeeId, Name = employee.Name, LastName = employee.LastName };
        }
    }

}
