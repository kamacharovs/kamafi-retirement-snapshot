using KamaFi.Retirement.Snapshot.Background.Workflow;
using KamaFi.Retirement.Snapshot.Background.Workflow.Contexts;
using KamaFi.Retirement.Snapshot.Background.Workflow.Interfaces;
using KamaFi.Retirement.Snapshot.Data.Options;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.Configure<BackgroundServiceOptions>(config.GetSection(nameof(BackgroundServiceOptions)))
    .Configure<BackgroundServiceApiOptions>(config.GetSection(nameof(BackgroundServiceApiOptions)))
    .AddHostedService<Marshaller>()
    .AddTransient<IStepContext, StepContext>()
    .AddTransient<IStep, InitializationStep>()
    .AddTransient<IStep, SecondaryStep>()
    .AddTransient<IStep, CheckCoreHealthStep>();

services.AddHealthChecks();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(e =>
{
    e.MapHealthChecks("/health");
});

app.Run();