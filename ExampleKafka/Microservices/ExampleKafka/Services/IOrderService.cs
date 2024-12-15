using ExampleOrderKafka.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleOrderKafka.Services
{
    public interface IOrderService
    {
         Task<Order> CreateOrder(Order order);
        IEnumerable<Order> GetOrders();
    }
}
