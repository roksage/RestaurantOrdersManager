using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the existing authentication setup
                services.RemoveAll(typeof(IAuthenticationSchemeProvider));

                // Add the custom test authentication handler
                services.AddAuthentication("Test")
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });

                // Ensure the test authentication is the default scheme
                services.AddAuthorization(options =>
                {
                    options.DefaultPolicy = new AuthorizationPolicyBuilder("Test")
                        .RequireAuthenticatedUser()
                        .Build();
                });
            });
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
