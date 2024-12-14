using Confluent.Kafka;
using ExampleOrderKafka.Models;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace ExampleOrderKafka.Services
{
    public class OrderService: IOrderService
    {
        private readonly IProducer<Null, string> _producer;
        public OrderService(IProducer<Null, string> producer)
        {
            _producer = producer;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };
            var message = JsonSerializer.Serialize(order, options);
            await _producer.ProduceAsync("orders", new Message<Null, string> { Value = message });

            return order;
        }
        public IEnumerable<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    Id =  1001,
                    Product = "product1",
                    Price = 1000,
                    Quantity =1,
                    Paid = true,
                    Created = DateTime.Now,
                    UserEmail =  "pshenichnykhaa@yandex.com"
                },
                new Order
                {
                    Id =  1002,
                    Product = "product2",
                    Price = 100,
                    Quantity =11,
                    Paid = true,
                    Created = DateTime.Now,
                    UserEmail =  "pshenichnykhaa@yandex.com"
                },
                new Order
                {
                    Id =  1003,
                    Product = "product3",
                    Price = 500,
                    Quantity = 10,
                    Paid = true,
                    Created = DateTime.Now,
                    UserEmail =  "pshenichnykhaa@yandex.com"
                }
            };
        }
    }
}
