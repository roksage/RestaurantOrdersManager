using Microsoft.AspNetCore.SignalR;

namespace RestaurantOrdersManager.WebAPI.Helpers
{
    public class CookingStationsHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("receive message", $"{Context.ConnectionId} has joined");
        }

        public async Task SendToWorkStations(string orders)
        {
            await Clients.All.SendAsync("SendToWorkStations ", orders);
        }
    }
}
