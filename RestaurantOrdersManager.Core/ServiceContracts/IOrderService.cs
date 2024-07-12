using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;


namespace RestaurantOrdersManager.Core.ServiceContracts
{
    public interface IOrderService
    {
        Task<OrderResponse> createOrder(OrderCreateRequest AddRequest);

        Task<List<OrderResponse>> GetAllOrders();   
    }
}
