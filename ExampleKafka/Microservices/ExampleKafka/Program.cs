using Confluent.Kafka;
using ExampleOrderKafka.Controllers;
using ExampleOrderKafka.Services;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IOrderService), typeof(OrderService));
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IProducer<Null, string>>(new ProducerBuilder<Null, string>(config).Build());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
