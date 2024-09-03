using Microsoft.AspNetCore.SignalR;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Core.Services.RestaurantOrdersServices;

namespace RestaurantOrdersManager.WebAPI.Helpers
{
    public class OrdersHub : Hub
    {
        private readonly ICookingStationService _cookingStationService;
        public OrdersHub(ICookingStationService cookingStationService) 
        { 
            _cookingStationService = cookingStationService;
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("receive message", $"{Context.ConnectionId} has joined");
        }

        public async Task SendToWorkStations(string orders)
        {
            await Clients.All.SendAsync("SendToWorkStations ", await _cookingStationService.GetAllCookingStations());
        }
    }
}
