using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RestaurantOrdersManager.Infrastructure;

namespace Entities
{
    public class RestaurantOrdersManagerContextFactory : IDesignTimeDbContextFactory<ManagerDbContext>
    {
        public ManagerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ManagerDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RestaurantOrdersManager;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ManagerDbContext(optionsBuilder.Options);
        }
    }
}