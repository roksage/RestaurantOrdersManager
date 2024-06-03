using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;


using RestaurantOrdersManager.Infrastructure;
using RestaurantOrdersManager.Core.Entities;


namespace RestaurantOrdersManager.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ManagerDbContext _dbContext;

        public EmployeeService(ManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeResponse> AddEmployee(EmployeeAddRequest AddRequest)
        {
            if (AddRequest == null)
            {
                throw new ArgumentNullException(nameof(AddRequest));
            }
            Employee employee = AddRequest.ToEmployee();
            _dbContext.Add(employee);
            await _dbContext.SaveChangesAsync(); 
            return employee.EmployeeResponse();
        }
    }
}
