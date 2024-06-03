using RestaurantOrdersManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO
{
    public class EmployeeAddRequest
    {

        [Required(ErrorMessage = "Please provide persons Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please provide persons LastName")]
        public string? LastName { get; set; }

        public Employee ToEmployee()
        {
            return new Employee() { Name = Name, LastName = LastName };
        }
    }
}
