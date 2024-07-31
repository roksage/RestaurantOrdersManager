using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemToOrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItem;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Core.Services.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;

namespace RestaurantOrdersManager.Tests
{
    public class MenuItemToOrderServiceTests
    {
        private async Task<RestaurantOrdersDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RestaurantOrdersDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new RestaurantOrdersDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync();
            await databaseContext.Database.EnsureDeletedAsync();

            var menuItemToOrder = new MenuItemToOrder { OrderedMenuItemId = 1, OrderId = 1, MenuItemId = 1, ProcessStarted = DateTime.Now.AddDays(-7) };
            var menuItem = new MenuItem { MenuItemId = 1, ItemName = "Burger" };
            var order = new Order { CreatedBy = 1 };


            databaseContext.Add(menuItemToOrder);
            databaseContext.Add(menuItem);
            databaseContext.Add(order);
            await databaseContext.SaveChangesAsync();

            return databaseContext;
        }
        [Fact]
        public async Task MenuItemToOrderService_MenuItemToOrderServiceAddRequest_MenuItemToOrderResponse()
        {
            var dbContext = await GetDbContext();

            var mockOrderService = new Mock<IOrderService>();

            var menuItemToOrderService = new MenuItemToOrderService(dbContext, mockOrderService.Object);

            MenuItemToOrderAddRequest request = new MenuItemToOrderAddRequest { MenuItemId = 1, OrderId = 1, ProcessStarted = DateTime.Now.AddHours(0) };

            MenuItemToOrderResponse act = await menuItemToOrderService.MenuItemToOrderServiceAddRequest(request);

            act.Should().BeEquivalentTo(request, options => options
                        .Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation, TimeSpan.FromMilliseconds(100)))
                        .WhenTypeIs<DateTime>());
        }

        [Fact]
        public async Task MenuItemToOrderService_GetAllMenuItemToOrderService_ListMenuItemToOrderResponse()
        {
            var dbContext = await GetDbContext();

            var mockOrderService = new Mock<IOrderService>();

            var menuItemToOrderService = new MenuItemToOrderService(dbContext, mockOrderService.Object);

            IEnumerable<MenuItemToOrderResponse> act = await menuItemToOrderService.GetAllMenuItemToOrderService();

            act.Should().HaveCount(1);
        }

        [Fact]
        public async Task MenuItemToOrderService_CompleteMenuItemInOrder_MenuItemToOrderResponse()
        {
            var dbContext = await GetDbContext();

            var mockOrderService = new Mock<IOrderService>();

            var menuItemToOrderService = new MenuItemToOrderService(dbContext, mockOrderService.Object);

            MenuItemToOrderResponse act = await menuItemToOrderService.CompleteMenuItemInOrder(new MenuItemToOrderCompleteMenuItemById { OrderedMenuItemId = 1 });

            act.ProcessCompleted.Should().NotBeNull();

        }

        [Fact]
        public async Task MenuItemToOrderService_CompleteMenuItemInOrder_KeyNotFoundException()
        {
            var dbContext = await GetDbContext();

            var mockOrderService = new Mock<IOrderService>();

            var menuItemToOrderService = new MenuItemToOrderService(dbContext, mockOrderService.Object);

            Func<Task> act = async () => await menuItemToOrderService.CompleteMenuItemInOrder(new MenuItemToOrderCompleteMenuItemById { OrderedMenuItemId = 2 });

            await act.Should().ThrowAsync<KeyNotFoundException>(); 
        }

        [Fact]
        public async Task MenuItemToOrderService_CompleteMenuItemInOrder_InvalidOperationException()
        {
            var dbContext = await GetDbContext();

            var mockOrderService = new Mock<IOrderService>();

            var menuItemToOrderService = new MenuItemToOrderService(dbContext, mockOrderService.Object);

            MenuItemToOrderResponse completeOrder = await menuItemToOrderService.CompleteMenuItemInOrder(new MenuItemToOrderCompleteMenuItemById { OrderedMenuItemId = 1 });


            Func<Task> act = async () => await menuItemToOrderService.CompleteMenuItemInOrder(new MenuItemToOrderCompleteMenuItemById { OrderedMenuItemId = 1 });

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

    }
}