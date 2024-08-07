using FluentAssertions;
using Humanizer;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.EmployeeDTO;
using System.Net.Http.Json;
using System.Text;

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
        public async Task EmployeeController_addEmployee_EmployeeResponse()
        {
            // Arrange
            var addRequest = new EmployeeAddRequest { Name = "name", LastName = "lastname" };

            // Act
            var response = await _client.PostAsJsonAsync("/api/Employee/addEmployee", addRequest);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<EmployeeResponse>(responseBody);

            // Create expected EmployeeResponse
            var expectedEmployeeResponse = addRequest.ToEmployee().ToEmployeeResponse();

            // Assert manually
            employee.Should().BeOfType<EmployeeResponse>();
            employee.Should().NotBeNull();
            employee.Name.Should().Be(expectedEmployeeResponse.Name);
            employee.LastName.Should().Be(expectedEmployeeResponse.LastName);
        }


        [Fact]
        public async Task EmployeeController_getAllEmployees_ListEmployees()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Employee/getAllEmpolyees");


            var response = await _client.SendAsync(request);

            var employees = JsonConvert.DeserializeObject<Employee[]>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            employees?.FirstOrDefault().Should().BeOfType<Employee>();
            employees?.Count().Should().BeGreaterThan(0);  
        }
    }
}