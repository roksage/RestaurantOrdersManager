using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Core.Services.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;

namespace RestaurantOrdersManager.Tests
{
    public class MenuItemServiceTests
    {
        private async Task<RestaurantOrdersDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RestaurantOrdersDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new RestaurantOrdersDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync();
            await databaseContext.Database.EnsureDeletedAsync();

            var menuItem = new MenuItem { MenuItemId = 1, ItemName = "Pizza" };



            databaseContext.Add(menuItem);
            await databaseContext.SaveChangesAsync();

            return databaseContext;
        }

        [Fact]

        public async Task MenuItemService_AddMenuItem_MenuItemResponse()
        {
            var dbContext = await GetDbContext();

            MenuItemService menuItemService = new MenuItemService(dbContext);

            MenuItemAddRequest addRequest = new MenuItemAddRequest { ItemName = "Dill" };

            MenuItemResponse act = await menuItemService.AddMenuItem(addRequest);

            MenuItemResponse findAdded = await menuItemService.FindMenuItemById(act.MenuItemId);

            act.Should().BeEquivalentTo(findAdded);
        }
        [Fact]
        public async Task MenuItemService_FindMenuItemById_MenuItemResponse()
        {
            var dbContext = await GetDbContext();

            MenuItemService menuItemService = new MenuItemService(dbContext);

            MenuItemResponse act = await menuItemService.FindMenuItemById(1);

            act.Should().NotBeNull();
        }
        [Fact]
        public async Task MenuItemService_FindMenuItemById_ListMenuItemResponse()
        {
            var dbContext = await GetDbContext();

            MenuItemService menuItemService = new MenuItemService(dbContext);

            IEnumerable<MenuItemResponse> act = await menuItemService.GetAllMenuItems();

            act.Should().HaveCount(1);
        }
        [Fact]

        public async Task MenuItemService_AddMenuItem_Exception()
        {
            var dbContext = await GetDbContext();

            MenuItemService menuItemService = new MenuItemService(dbContext);

            MenuItemAddRequest addRequest = null;

            Func<Task> act = async () => await menuItemService.AddMenuItem(addRequest);


            await act.Should().ThrowAsync<ArgumentNullException>();
        }

    }
}