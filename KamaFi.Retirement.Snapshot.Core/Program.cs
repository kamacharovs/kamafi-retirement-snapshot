using System.Text.Json.Serialization;
using System.Text.Json;
using KamaFi.Retirement.Snapshot.Data.Options;
using KamaFi.Retirement.Snapshot.Services;
using KamaFi.Retirement.Snapshot.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.AddDataConfiguration(config)
    .AddTransient<IRetirementRepository, RetirementRepository>()
    .AddTransient<IRetirementFactRepository, RetirementFactRepository>()
    .AddSingleton<IInformationRepository, InformationRepository>();

services.AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .Configure<RetirementSnapshotOptions>(config.GetSection(RetirementSnapshotOptions.Section));

services.AddControllers();
services.AddHealthChecks();
services.AddMvcCore()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(e =>
{
    e.MapControllers();
    e.MapHealthChecks("/health");
});

app.Run();
