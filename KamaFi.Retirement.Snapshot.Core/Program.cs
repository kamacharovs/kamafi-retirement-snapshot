using KamaFi.Retirement.Snapshot.Data;
using KamaFi.Retirement.Snapshot.Data.Options;
using System.Text.Json.Serialization;
using System.Text.Json;
using KamaFi.Retirement.Snapshot.Services;
using KamaFi.Retirement.Snapshot.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.AddDataConfiguration(config)
    .AddTransient<IRetirementFactRepository, RetirementFactRepository>();

services.AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .Configure<RetirementSnapshotOptions>(config.GetSection(RetirementSnapshotOptions.Section));

services.AddControllers();
services.AddMvcCore()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
