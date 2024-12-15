using Confluent.Kafka;
using ExampleNotificationKafka.Models;
using ExampleOrderKafka.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using static Confluent.Kafka.ConfigPropertyNames;

namespace ExampleNotificationKafka.Controllers
{
    public class NotificationController : ControllerBase
    {
        private readonly string orderTopic = "orders";
        private readonly IConsumer<Ignore, string> consumer;
        private readonly IProducer<string, string> _producer;
        private readonly ConsumerConfig config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "test-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            
        };
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        public NotificationController(IProducer<string, string> producer)
        {
            consumer = new ConsumerBuilder<Ignore, string>(config)
            .SetValueDeserializer(Deserializers.Utf8)
            .Build();
            _producer = producer;
        }

        [HttpGet("notifications/start")]
        public void StartListening()
        {
            consumer.Subscribe(orderTopic);
            Task.Run(() =>
            {
                while (true)
                {
                    var cr = consumer.Consume();
                    var order = JsonSerializer.Deserialize<Order>(cr.Message.Value);
                    var notification = new Notification
                    {
                        NotificationId = Guid.NewGuid(),
                        OrderId = order.Id,
                        Message = $"Вы успешно заказали {order.Product}.",
                        Email = order.UserEmail,
                    };
                    var messageNotification = JsonSerializer.Serialize(notification, options);
                    //Todo отправка Email
                    // Console.WriteLine($"Уведомление: {notification.Message}");
                    _producer.ProduceAsync("notifications",
                                            new Message<string, string>
                                            {
                                              Key = notification.NotificationId.ToString(),
                                              Value = messageNotification
                                            }
                    );
                }
            });
        }
    }
}
