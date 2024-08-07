using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RestaurantOrdersManager.Infrastructure;

namespace RestaurantOrdersManager.API.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the existing RestaurantOrdersDbContext registration
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<RestaurantOrdersDbContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add the in-memory database for testing
                services.AddDbContext<RestaurantOrdersDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDatabase");
                });

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<RestaurantOrdersDbContext>();

                    db.Database.EnsureCreated();


                }

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
