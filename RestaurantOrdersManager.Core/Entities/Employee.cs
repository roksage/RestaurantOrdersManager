using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Please provide employee name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide employee lastname")]
        public string LastName {  get; set; }
    }
}
