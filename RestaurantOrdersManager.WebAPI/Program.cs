using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantOrdersManager.Core.ServiceContracts;
using RestaurantOrdersManager.Core.Services;
using RestaurantOrdersManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<ManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ManagerDbContext")));

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        c.RoutePrefix = "";
    });
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
