using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemToOrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Core.Services.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;

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
            var order = new Order
            {
                OrderId = 1,
                CreatedBy = 1,
                TableId = 1,
                TimeCreated = DateTime.Now,
                OrderMenuItems = new List<MenuItemToOrder>
                {
                    new MenuItemToOrder
                    {
                        MenuItemId = 2,
                        OrderId = 1,
                        MenuItem = new MenuItem
                        {
                            MenuItemId = 2,
                            ItemName = "Pizza"
                        },
                        ProcessStarted = DateTime.Now
                    }
                }
            };


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

            OrderCreateRequest order = new OrderCreateRequest { CreatedBy = 1, TableId = 1 };

            OrderResponse act = await orderService.createOrder(order);

            OrderResponse response = await orderService.GetOrderByOrderId(act.OrderId);

            act.Should().BeEquivalentTo(response);
        }

        [Fact]

        public async Task OrderService_createOrder_NullException()
        {
            var dbContext = await GetDbContext();

            var MockEmployeeService = new Mock<IEmployeeService>();
            var MockTableService = new Mock<ITableService>();

            var orderService = new OrderService(dbContext, MockEmployeeService.Object, MockTableService.Object);

            OrderCreateRequest order = null;

            Func<Task> act = async () => await orderService.createOrder(order);


            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]

        public async Task OrderService_createOrder_ExceptionEmployeeNotFound()
        {
            var dbContext = await GetDbContext();

            var MockEmployeeService = new Mock<IEmployeeService>();
            var MockTableService = new Mock<ITableService>();

            MockEmployeeService.Setup(s => s.GetEmployeeById(It.IsAny<int>()))
                               .ReturnsAsync((EmployeeResponse?)null);

            MockTableService.Setup(s => s.GetTableById(It.IsAny<int>()))
                            .ReturnsAsync((int id) => new TableResponse { TableId = id, TableName = "Table 1", Seats = 2, Status = Core.Enums.TableStatusEnums.Free });

            var orderService = new OrderService(dbContext, MockEmployeeService.Object, MockTableService.Object);

            OrderCreateRequest order = new OrderCreateRequest { CreatedBy = 2, TableId = 1 };

            Func<Task> act = async () => await orderService.createOrder(order);

            await act.Should().ThrowAsync<InvalidOperationException>().WithMessage($"Employee with id {order.CreatedBy} not found.");
        }

        [Fact]

        public async Task OrderService_createOrder_ExceptionTableNotFound()
        {
            var dbContext = await GetDbContext();

            var MockEmployeeService = new Mock<IEmployeeService>();
            var MockTableService = new Mock<ITableService>();

            MockEmployeeService.Setup(s => s.GetEmployeeById(It.IsAny<int>()))
                               .ReturnsAsync((int id) => new EmployeeResponse { EmployeeId = 1, LastName = "Test", Name = "Unit" });

            MockTableService.Setup(s => s.GetTableById(It.IsAny<int>()))
                            .ReturnsAsync((int id) => new TableResponse { TableId = id, TableName = "Table 1", Seats = 2, Status = Core.Enums.TableStatusEnums.Reserved });


            var orderService = new OrderService(dbContext, MockEmployeeService.Object, MockTableService.Object);

            OrderCreateRequest order = new OrderCreateRequest { CreatedBy = 2, TableId = 1 };

            Func<Task> act = async () => await orderService.createOrder(order);

            await act.Should().ThrowAsync<InvalidOperationException>().WithMessage($"Table with id {order.CreatedBy} not found.");
        }


        [Fact]

        public async Task OrderService_GetAllMenuItemsInOrder_ListOrder()
        {
            var dbContext = await GetDbContext();

            var MockEmployeeService = new Mock<IEmployeeService>();
            var MockTableService = new Mock<ITableService>();
            var orderService = new OrderService(dbContext, MockEmployeeService.Object, MockTableService.Object);


            IEnumerable<MenuItemToOrderResponse> orders = await orderService.GetAllMenuItemsInOrder(1);

            orders.Should().HaveCount(1);
        }


        [Fact]

        public async Task OrderService_GetAllMenuItemsInOrder_ArgumentNullException()
        {
            var dbContext = await GetDbContext();

            var MockEmployeeService = new Mock<IEmployeeService>();
            var MockTableService = new Mock<ITableService>();
            var orderService = new OrderService(dbContext, MockEmployeeService.Object, MockTableService.Object);

            Func<Task> act = async () => await orderService.GetAllMenuItemsInOrder(null);

            await act.Should().ThrowAsync<ArgumentNullException>();
        }
        [Fact]

        public async Task OrderService_GetAllMenuItemsInOrder_Exception()
        {
            var dbContext = await GetDbContext();

            var MockEmployeeService = new Mock<IEmployeeService>();
            var MockTableService = new Mock<ITableService>();
            var orderService = new OrderService(dbContext, MockEmployeeService.Object, MockTableService.Object);

            Func<Task> act = async () => await orderService.GetAllMenuItemsInOrder(2);

            await act.Should().ThrowAsync<Exception>().WithMessage($"Order with id {2} not found.");
        }

        [Fact]

        public async Task OrderService_GetAllOrders_ListOrderResponse()
        {
            var dbContext = await GetDbContext();

            var MockEmployeeService = new Mock<IEmployeeService>();
            var MockTableService = new Mock<ITableService>();
            var orderService = new OrderService(dbContext, MockEmployeeService.Object, MockTableService.Object);

            IEnumerable<OrderResponse> act = await orderService.GetAllOrders();

            act.Should().HaveCount(1);

        }


        [Fact]

        public async Task OrderService_CheckIfOrderIsCompleted_bool()
        {
            var dbContext = await GetDbContext();

            var MockEmployeeService = new Mock<IEmployeeService>();
            var MockTableService = new Mock<ITableService>();
            var orderService = new OrderService(dbContext, MockEmployeeService.Object, MockTableService.Object);

            bool act = await orderService.CheckIfOrderIsCompleted(1);

            act.Should().BeFalse();

        }

        [Fact]
        public async Task OrderService_GetAllActiveOrders_ListOrderResponse()
        {
            var dbContext = await GetDbContext();

            var MockEmployeeService = new Mock<IEmployeeService>();
            var MockTableService = new Mock<ITableService>();
            var orderService = new OrderService(dbContext, MockEmployeeService.Object, MockTableService.Object);

            IEnumerable<OrderResponse> act = await orderService.GetAllOrders();
            act.Should().HaveCount(1);
        }



        [Fact]
        public async Task OrderService_GetOrderByOrderId_OrderResponse()
        {
            var dbContext = await GetDbContext();

            var MockEmployeeService = new Mock<IEmployeeService>();
            var MockTableService = new Mock<ITableService>();
            var orderService = new OrderService(dbContext, MockEmployeeService.Object, MockTableService.Object);

            OrderResponse act = await orderService.GetOrderByOrderId(1);

            act.OrderMenuItems.FirstOrDefault().MenuItemId.Should().Be(2);

        }
    }
}