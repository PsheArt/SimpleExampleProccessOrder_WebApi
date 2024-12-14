using Shop_WebClient.Models;
using Shed.CoreKit.WebApi;

namespace Shop_WebClient.Services
{
    public class OrderService
    {
        private readonly ApiClient _apiClient;
        

        public OrderService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            var response = await _apiClient.PostAsync<Order>("api/orders", order);
            return response.Data;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var response = await _apiClient.GetAsync<List<Order>>("api/orders");
            return response.Data;
        }
    }
}
