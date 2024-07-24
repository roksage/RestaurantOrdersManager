using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;

namespace RestaurantOrdersManager.Core.Services.RestaurantOrdersServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly RestaurantOrdersDbContext _dbContext;

        public EmployeeService(RestaurantOrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeResponse> AddEmployee(EmployeeAddRequest AddRequest)
        {
            if (AddRequest == null)
            {
                throw new ArgumentNullException(nameof(AddRequest));
            }

            //check if user is unique

            Employee? findEmployee = await _dbContext.Employees.FirstOrDefaultAsync(em => em.Name == AddRequest.Name && em.LastName == AddRequest.LastName);

            if (findEmployee != null)
            {
                throw new InvalidOperationException("Employee already exists");
            }


            Employee employee = AddRequest.ToEmployee();
            _dbContext.Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee.ToEmployeeResponse();
        }



        public async Task<IEnumerable<EmployeeResponse>> GetAllEmployee()
        {
            try
            {
                return await _dbContext.Employees.Select(emp => emp.ToEmployeeResponse()).ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle all other exceptions
                throw new Exception("An unexpected error occurred while retrieving employees.", ex);
            }
        }

        public async Task<EmployeeResponse?> GetEmployeeById(int employeeId)
        {
            Employee? employee = await _dbContext.Employees.FirstOrDefaultAsync(em => em.EmployeeId == employeeId);
            if (employee == null)
            {
                return null;
            }
            return employee.ToEmployeeResponse();
        }
    }
}
