using KamaFi.Retirement.Snapshot.Data;
using KamaFi.Retirement.Snapshot.Data.Options;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.AddControllers();
services.AddMvcCore()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

services.AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .Configure<RetirementSnapshotOptions>(config.GetSection(RetirementSnapshotOptions.Section));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
