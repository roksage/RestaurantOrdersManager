using Microsoft.AspNetCore.SignalR;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;

namespace RestaurantOrdersManager.WebAPI.Helpers
{
    public class OrdersHub : Hub
    {
        private readonly IOrderService _OrderService;
        public OrdersHub(IOrderService OrderService) 
        { 
            _OrderService = OrderService;
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Successfully connected", await _OrderService.GetAllActiveOrdersWithCompletionStatus());
        }
    }
}
