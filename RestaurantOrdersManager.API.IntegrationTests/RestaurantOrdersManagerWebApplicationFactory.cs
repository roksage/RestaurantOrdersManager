using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Infrastructure;


namespace RestaurantOrdersManager.API.IntegrationTests
{
    internal class RestaurantOrdersManagerWebApplicationFactory : WebApplicationFactory<Program>
    {




        protected override IHost CreateHost(IHostBuilder builder)
        {
            // Add mock/test services to the builder here
            builder.ConfigureServices(services =>
            {
                services.AddScoped(scope =>
                {
                    // Replace SQLite with in-memory database for tests
                    return new DbContextOptionsBuilder<RestaurantOrdersDbContext>()
                        .UseInMemoryDatabase("Tests")
                        .UseApplicationServiceProvider(scope)
                        .Options;
                });

                // Ensure the database is seeded
                var serviceProvider = services.BuildServiceProvider();
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<RestaurantOrdersDbContext>();
                    SeedDatabase(db);
                }
            });

            return base.CreateHost(builder);
        }

        private void SeedDatabase(RestaurantOrdersDbContext context)
        {
            // Ensure the database is created
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}

        //protected override void ConfigureWebHost(IWebHostBuilder builder)
        //{
        //    builder.ConfigureTestServices(services =>
        //    {
        //        services.RemoveAll(typeof(DbContextOptions<RestaurantOrdersDbContext>));


        //        var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        //        services.AddSqlServer<RestaurantOrdersDbContext>(connectionString);

        //        var dbContext = CreateDbContext(services);
        //        dbContext.Database.EnsureCreated();
        //        dbContext.Database.EnsureDeleted();

        //    });
        //}

        //private static RestaurantOrdersDbContext CreateDbContext(IServiceCollection services)
        //{
        //    var serviceProvider = services.BuildServiceProvider();
        //    var scope = serviceProvider.CreateScope();
        //    var dbContext = scope.ServiceProvider.GetRequiredService<RestaurantOrdersDbContext>();
        //    return dbContext;
        //}
