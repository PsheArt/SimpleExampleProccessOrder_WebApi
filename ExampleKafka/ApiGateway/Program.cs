using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Configuration/ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();


var app = builder.Build();

await app.UseOcelot();
app.Run();
