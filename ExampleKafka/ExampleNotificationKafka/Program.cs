using Confluent.Kafka;
using Newtonsoft.Json;
using System.Text;
using ExampleNotificationKafka.Models;
using ExampleOrderKafka.Models;
using ExampleOrderKafka.Controllers;
using ExampleNotificationKafka.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
builder.Services.AddSingleton<IProducer<Null, string>>(new ProducerBuilder<Null, string>(config).Build());
builder.Services.AddControllers();
builder.Services.AddScoped<NotificationController>();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
