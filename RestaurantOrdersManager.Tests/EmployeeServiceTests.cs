using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.Services.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;

namespace RestaurantOrdersManager.Tests
{
    public class EmployeeServiceTests
    {

        private async Task<RestaurantOrdersDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RestaurantOrdersDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new RestaurantOrdersDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync();
            await databaseContext.Database.EnsureDeletedAsync();

            var employee = new Employee
            {
                Name = "John123123123123333333",
                LastName = "Doe"
            };

            databaseContext.Add(employee);
            await databaseContext.SaveChangesAsync();

            return databaseContext;
        }


        [Fact]
        public async Task Employees_AddEmployee_ReturnEmployee()
        {
            var employee = new EmployeeAddRequest
            {
                Name = "John1231231233313333",  
                LastName = "Doe"
            };

            var dbContext = await GetDbContext();
            var EmployeeService = new EmployeeService(dbContext);

            EmployeeResponse act = await EmployeeService.AddEmployee(employee);

            EmployeeResponse findEmployee = await EmployeeService.GetEmployeeById(act.EmployeeId);

            act.Should().Be(findEmployee);
        }

        [Fact]
        public async Task Employees_GetAllEmployee_ReturnEmoplyees()
        {
            var dbContext = await GetDbContext();
            var EmployeeService = new EmployeeService(dbContext);

            IEnumerable<EmployeeResponse> result = await EmployeeService.GetAllEmployee();
            EmployeeResponse employee = result.FirstOrDefault();
            result.Should().Contain(employee);
            result.Should().HaveCount(1);
        }

        [Fact]
        public async Task Emploee_GetEmployeeById_ReturnSpecificEmployee()
        {
            var dbContext = await GetDbContext();
            var EmployeeService = new EmployeeService(dbContext);

            EmployeeResponse act = await EmployeeService.AddEmployee(new EmployeeAddRequest { Name = "Second",
                                                                                                      LastName = "SecondLast" });

            EmployeeResponse employee = await EmployeeService.GetEmployeeById(act.EmployeeId);

            act.Should().Be(employee);
        }
    }
}