using KamaFi.Retirement.Snapshot.Background.Workflow;
using KamaFi.Retirement.Snapshot.Background.Workflow.Interfaces;
using KamaFi.Retirement.Snapshot.Data.Options;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.Configure<BackgroundServiceOptions>(config.GetSection(nameof(BackgroundServiceOptions)))
    .AddHostedService<Marshaller>()
    .AddTransient<IStep, InitializationStep>()
    .AddTransient<IStep, SecondaryStep>();

services.AddHealthChecks();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(e =>
{
    e.MapHealthChecks("/health");
});

app.Run();