using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Infrastructure;
using System;
using System.Threading.Tasks;


namespace RestaurantOrdersManager.Tests
{
    public class EmployeeServiceTests
    {

        private async Task<RestaurantOrdersDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RestaurantOrdersDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            
            if(await databaseContext.Employees.CountAsync() < 0)
            {
                databaseContext.Employees.Add(
                new Employee { EmployeeId = 1, Name = "John", LastName = "Doe" },
                new Employee { EmployeeId = 2, Name = "Jane", LastName = "Smith" },
                new Employee { EmployeeId = 3, Name = "Alice", LastName = "Johnson" },
                new Employee { EmployeeId = 4, Name = "Bob", LastName = "Brown" },
                new Employee { EmployeeId = 5, Name = "Charlie", LastName = "Davis" }
                );

                    await databaseContext.SaveChangesAsync();
            }

        }



        [Fact]
        public void Test1()
        {

        }
    }
}