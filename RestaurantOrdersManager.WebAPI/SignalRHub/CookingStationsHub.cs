using Microsoft.AspNetCore.SignalR;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;

namespace RestaurantOrdersManager.WebAPI.Helpers
{
    public class CookingStationsHub : Hub
    {
        private readonly ICookingStationService _cookingStationService;
        public CookingStationsHub(ICookingStationService cookingStationService)
        {
            _cookingStationService = cookingStationService;
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Successfully connected", await _cookingStationService.GetAllCookingStationsWithPendingItems());
        }
    }
}
