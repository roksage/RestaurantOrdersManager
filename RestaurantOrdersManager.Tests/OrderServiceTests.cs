using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Core.Services.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Tests
{
    public class OrderServiceTests
    {
        private async Task<RestaurantOrdersDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RestaurantOrdersDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new RestaurantOrdersDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync();
            await databaseContext.Database.EnsureDeletedAsync();

            var table = new Table { TableId = 1, TableName = "Table 1", Seats = 2, Status = Core.Enums.TableStatusEnums.Free };
            var employee = new Employee { EmployeeId = 1, Name = "Alfa", LastName = "Beta" };
            var order = new Order { OrderId = 1, CreatedBy = 1, TableId = 1, TimeCreated = DateTime.Now };
            
            databaseContext.Add(order);
            databaseContext.Add(employee);
            databaseContext.Add(table);
            await databaseContext.SaveChangesAsync();

            return databaseContext;
        }

        [Fact]

        public async Task OrderService_createOrder_OrderResponse()
        {
            var dbContext = await GetDbContext();

            var MockEmployeeService = new Mock<IEmployeeService>();
            var MockTableService = new Mock<ITableService>();

            MockEmployeeService.Setup(s => s.GetEmployeeById(It.IsAny<int>()))
                               .ReturnsAsync((int id) => new EmployeeResponse { EmployeeId = id, Name = "Alfa", LastName = "Beta" });

            MockTableService.Setup(s => s.GetTableById(It.IsAny<int>()))
                            .ReturnsAsync((int id) => new TableResponse { TableId = id, TableName = "Table 1", Seats = 2, Status = Core.Enums.TableStatusEnums.Free });

            var orderService = new OrderService(dbContext, MockEmployeeService.Object, MockTableService.Object);

            OrderCreateRequest order = new OrderCreateRequest {  CreatedBy = 1, TableId = 1 };

            OrderResponse act = await orderService.createOrder(order);

            OrderResponse response = await orderService.GetOrderByOrderId(act.OrderId);

            act.Should().BeEquivalentTo(response);
        }
    }
}
