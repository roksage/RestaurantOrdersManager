using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts
{
    public interface IEmployeeService
    {
        Task<EmployeeResponse> AddEmployee(EmployeeAddRequest AddRequest);  
        Task<IEnumerable<EmployeeResponse>> GetAllEmployee();

        Task<EmployeeResponse> GetEmployeeById(int id);
    }
}
