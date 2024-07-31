using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.Enums;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.IngredientDTO;
using RestaurantOrdersManager.Core.Services.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;

namespace RestaurantOrdersManager.Tests
{
    public class IngredientServiceTests
    {
        private async Task<RestaurantOrdersDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RestaurantOrdersDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new RestaurantOrdersDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync();
            await databaseContext.Database.EnsureDeletedAsync();

            var ingredient = new Ingredient
            {
                IngredientId = 0,
                IngredientName = "Lettuce",
                IngredientUnit = IngredientEnums.Gram,
                IngredientAmount = 500
            };



            databaseContext.Add(ingredient);
            await databaseContext.SaveChangesAsync();

            return databaseContext;
        }
        [Fact]

        public async Task Ingredient_CreateIngredientandFindIngredientById_IngredientResponse()
        {
            var dbContext = await GetDbContext();

            IngredientService ingredientService = new IngredientService(dbContext);

            IngredientAddRequest ingredientDetails = new IngredientAddRequest
            {
                IngredientName = "Ketchup",
                IngredientUnit = IngredientEnums.Gram,
                IngredientAmount = 50
            };


            IngredientResponse act = await ingredientService.CreateIngredient(ingredientDetails);

            IngredientResponse getIngredient = await ingredientService.FindIngredientById(act.IngredientId);

            act.Should().BeEquivalentTo(getIngredient);

        }
        [Fact]
        public async Task Ingredient_GetAllIngredient_ListTypeOfIngredientResponse()
        {
            var dbContext = await GetDbContext();
            IngredientService ingredientService = new IngredientService(dbContext);

            IEnumerable<IngredientResponse> act = await ingredientService.GetAllIngredients();

            act.Should().HaveCount(1);
            act.FirstOrDefault().Should().BeEquivalentTo(await ingredientService.FindIngredientById(1));
        }


        [Fact]
        public async Task Ingredient_UpdateIngredient_IngredientResponse()
        {
            var dbContext = await GetDbContext();
            IngredientService ingredientService = new IngredientService(dbContext);

            IngredientUpdateRequest updateRequest = new IngredientUpdateRequest
            {
                IngredientId = 1,
                IngredientName = "Chips",
                IngredientUnit = IngredientEnums.Gram,
                IngredientAmount = 10
            };

            IngredientResponse act = await ingredientService.UpdateIngredient(updateRequest);

            act.Should().BeEquivalentTo(updateRequest.ToIngredient().ToIngredientResponse());
        }

        [Fact]
        public async Task Ingredient_UpdateIngredient_Exceptions()
        {
            var dbContext = await GetDbContext();
            IngredientService ingredientService = new IngredientService(dbContext);

            IngredientUpdateRequest updateRequest = new IngredientUpdateRequest
            {
                IngredientId = 51231230,
                IngredientName = "Ketchup",
                IngredientUnit = IngredientEnums.Gram,
                IngredientAmount = 12
            };

            Func<Task> act = async () => await ingredientService.UpdateIngredient(updateRequest);

            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task IngrdientService_DeleteIngredient_BoolTrue()
        {
            var dbContext = await GetDbContext();
            IngredientService ingredientService = new IngredientService(dbContext);

            IngredientDeleteRequest request = new IngredientDeleteRequest
            {
                IngredientId = 1
            };

            bool act = await ingredientService.DeleteIngredient(request);

            act.Should().BeTrue();

        }

        [Fact]
        public async Task IngrdientService_DeleteIngredient_Exception()
        {
            var dbContext = await GetDbContext();
            IngredientService ingredientService = new IngredientService(dbContext);

            IngredientDeleteRequest request = new IngredientDeleteRequest
            {
                IngredientId = 5
            };

            Func<Task> act = async () => await ingredientService.DeleteIngredient(request);

            await act.Should().ThrowAsync<ArgumentException>();

        }

        [Fact]

        public async Task IngredientService_CreateIngredient_ExceptionsNull()
        {
            var dbContext = await GetDbContext();
            IngredientService ingredientService = new IngredientService(dbContext);

            IngredientAddRequest request = null;

            Func<Task> act = async () => await ingredientService.CreateIngredient(request);

            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task IngredientService_CreateIngredient_ExceptionsArgument()
        {
            var dbContext = await GetDbContext();
            IngredientService ingredientService = new IngredientService(dbContext);

            IngredientAddRequest request = new IngredientAddRequest {
            IngredientName = "Lettuce",
            };

            Func<Task> act = async () => await ingredientService.CreateIngredient(request);

            await act.Should().ThrowAsync<ArgumentException>().WithMessage($"Ingredient with this name already exist {request.IngredientName}");
        }
    }
}
