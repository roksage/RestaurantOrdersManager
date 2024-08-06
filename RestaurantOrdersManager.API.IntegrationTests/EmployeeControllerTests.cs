using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using System.Net.Http.Json;

namespace RestaurantOrdersManager.API.IntegrationTests
{
    public class MyIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {

        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public MyIntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }


        [Fact]

        public async Task Test()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Employee/getAllEmpolyees");


            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();


        }
    }
}