using System.Text.Json.Serialization;
using System.Text.Json;
using KamaFi.Retirement.Snapshot.Common.Settings;
using KamaFi.Retirement.Snapshot.Application.Factories.Interfaces;
using KamaFi.Retirement.Snapshot.Application.Repositories.Interfaces;
using KamaFi.Retirement.Snapshot.Infrastructure.Factories;
using KamaFi.Retirement.Snapshot.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.Configure<CosmosDbSettings>(config.GetSection(CosmosDbSettings.Section));

services.AddScoped<ICosmosDbFactory, CosmosDbFactory>()
    .AddScoped<IUserRepository, UserRepository>();

services.AddControllers();
services.AddHealthChecks();
services.AddMvcCore()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(e =>
{
    e.MapControllers();
    e.MapHealthChecks("/health");
});

app.Run();