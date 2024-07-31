using RestaurantOrdersManager.Core.Entities;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderedMenuItemDTO;


namespace RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices
{
    public interface IOrderService
    {
        Task<OrderResponse> createOrder(OrderCreateRequest AddRequest);

        Task<IEnumerable<OrderResponse>> GetAllOrders();

        Task<IEnumerable<OrderResponse>> GetAllActiveOrders();

        Task<IEnumerable<MenuItemToOrderResponse>> GetAllMenuItemsInOrder(int? OrderId);

        Task<bool> CheckIfOrderIsCompleted(int MenuItemId);

        Task<OrderResponse> GetOrderByOrderId(int OrderId);
    }
}
