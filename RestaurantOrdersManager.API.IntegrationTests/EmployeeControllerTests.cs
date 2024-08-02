using FluentAssertions;
using NuGet.Protocol;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using System.Net.Http.Json;

namespace RestaurantOrdersManager.API.IntegrationTests
{
    public class EmployeeControllerTests
    {
        [Fact]
        public async Task GetAllEmpolyees()
        {
            var application = new RestaurantOrdersManagerWebApplicationFactory();

            EmployeeAddRequest request = new EmployeeAddRequest { Name = "Integration", LastName = "Test" };
            
            var client = application.CreateClient();

            var response1 = await client.PostAsJsonAsync("api/Employee/addEmployee", request);

            var response = await client.GetAsync("api/Table/GetAllTablesFreeOccupied?status=0");

            var employees = await response.Content.ReadFromJsonAsync<List<Table>>();


            response1.EnsureSuccessStatusCode();
        }
    }
}