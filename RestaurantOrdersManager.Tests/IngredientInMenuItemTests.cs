using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientInMenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.MenuItemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Core.Services.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;

namespace RestaurantOrdersManager.Tests
{
    public class IngredientInMenuItemTests
    {
        private async Task<RestaurantOrdersDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RestaurantOrdersDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new RestaurantOrdersDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync();
            await databaseContext.Database.EnsureDeletedAsync();

            var ingredientInMenuItem = new IngredientInMenuItem
            {
                IngredientInMenuItemId = 2,
                IngredientId = 2,
                MenuItemId = 3
            };



            databaseContext.Add(ingredientInMenuItem);
            await databaseContext.SaveChangesAsync();

            return databaseContext;
        }

        [Fact]

        public async Task ingredientInMenuItem_AddingredientInMenuItem_ingredientInMenuItemResponse()
        {
            var dbContext = await GetDbContext();

            var menuItemServiceMock = new Mock<IMenuItemService>();
            var ingredientServiceMock = new Mock<IIngredientService>();

            var ingredientInMenuItemService = new IngredientInMenuItemService(dbContext, menuItemServiceMock.Object, ingredientServiceMock.Object);

            IngredientInMenuItemResponse addItem = await ingredientInMenuItemService.AddIngredientToMenuItem(new IngredientInMenuItemAddRequest
            {
                IngredientId = 4,
                MenuItemId = 3
            });


            bool act = await ingredientInMenuItemService.GetIngredientInMenuItemByIds(new IngredientInMenuItemAddRequest { MenuItemId = addItem.MenuItemId, IngredientId = addItem.IngredientId });

            Assert.True(act);
        }


        [Fact]
        public async Task ingredientInMenuItem_GetIngredientInMenuItemByIds_ingredientInMenuItemResponseList()
        {
            var dbContext = await GetDbContext();
            var menuItemServiceMock = new Mock<IMenuItemService>();
            var ingredientServiceMock = new Mock<IIngredientService>();
            var ingredientInMenuItemService = new IngredientInMenuItemService(dbContext, menuItemServiceMock.Object, ingredientServiceMock.Object);

            

            IngredientInMenuItemResponse addItem = await ingredientInMenuItemService.AddIngredientToMenuItem(new IngredientInMenuItemAddRequest
            {
                IngredientId = 4,
                MenuItemId = 4
            });

            IEnumerable<IngredientInMenuItemResponse> act = await ingredientInMenuItemService.GetAllIngredientInMenuItem();

            act.Should().Contain(addItem);
            act.Should().HaveCount(2);

        }
    }
}
