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
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Employees.CountAsync() < 0)
            {
                databaseContext.Employees.Add(
                new Employee { EmployeeId = 1, Name = "J1ohn", LastName = "Doe" }
                );
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }


        [Fact]
        public async void Employees_AddEmployee_ReturnEmployee()
        {
            var employee = new EmployeeAddRequest
            {
                Name = "John12312312333333",  
                LastName = "Doe"
            };


            var dbContext = await GetDbContext();
            var EmployeeService = new EmployeeService(dbContext);

            EmployeeResponse result = await EmployeeService.AddEmployee(employee);

            EmployeeResponse findEmployee = await EmployeeService.GetEmployeeById(result.EmployeeId);

            result.Should().BeSameAs(findEmployee);
            result.Should().BeOfType<EmployeeResponse>();
            result.Should().BeEquivalentTo(findEmployee);
        }
    }
}