using RestaurantOrdersManager.Core.ServiceContracts.DTO.OrderDTO;


namespace RestaurantOrdersManager.Core.ServiceContracts
{
    public interface IOrderService
    {
        Task<OrderResponse> createOrder(OrderAddRequest AddRequest);

        Task<List<OrderResponse>> GetAllOrders();   
    }
}
