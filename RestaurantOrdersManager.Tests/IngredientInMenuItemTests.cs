using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Tests
{
    public class Class1
    {
        private async Task<RestaurantOrdersDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RestaurantOrdersDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new RestaurantOrdersDbContext(options);
            databaseContext.Database.EnsureCreatedAsync();
            databaseContext.Database.EnsureDeletedAsync();

            var employee = new IngredientInMenuItem
            {

            };

            databaseContext.Add(employee);
            databaseContext.SaveChangesAsync();

            return databaseContext;
        }
    }
}
