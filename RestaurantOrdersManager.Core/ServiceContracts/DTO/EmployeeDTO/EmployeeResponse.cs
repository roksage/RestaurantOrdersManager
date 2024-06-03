using RestaurantOrdersManager.Core.Entities;
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
    }
    public static class EmployeeResponseExtension
    {
        public static EmployeeResponse EmployeeResponse(this Employee employee)
        {
            return new EmployeeResponse { EmployeeId = employee.EmployeeId, Name = employee.Name, LastName = employee.LastName };
        }
    }
}
