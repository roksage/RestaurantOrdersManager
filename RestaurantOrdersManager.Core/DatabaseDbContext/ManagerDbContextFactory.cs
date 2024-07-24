using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RestaurantOrdersManager.Infrastructure;

namespace Entities
{
    public class RestaurantOrdersManagerContextFactory : IDesignTimeDbContextFactory<RestaurantOrdersDbContext>
    {
        public RestaurantOrdersDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestaurantOrdersDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new RestaurantOrdersDbContext(optionsBuilder.Options);
        }
    }
}