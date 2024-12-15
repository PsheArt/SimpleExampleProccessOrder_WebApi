using Microsoft.AspNetCore.Mvc;
using Confluent.Kafka;
using System.Threading.Tasks;
using ExampleOrderKafka.Models;
using System.Text.Json;
using ExampleOrderKafka.Services;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Options;
using static Confluent.Kafka.ConfigPropertyNames;

namespace ExampleOrderKafka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly string orderTopic = "orders";
        private IOrderService orderService;
        private readonly IConsumer<Ignore, string> consumer;
        private readonly ConsumerConfig config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "test-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest,

        };
        public OrdersController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            var createdOrder = await orderService.CreateOrder(order);
            //return CreatedAtAction(nameof(CreateOrder), new { id = createdOrder.Id }, createdOrder);
            return Ok(createdOrder);
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(orderService.GetOrders());
        }
    }
}
