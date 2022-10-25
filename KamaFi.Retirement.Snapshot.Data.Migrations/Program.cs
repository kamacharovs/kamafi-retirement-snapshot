using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using KamaFi.Retirement.Snapshot.Data.Extensions;
using KamaFi.Retirement.Snapshot.Data;
using KamaFi.Retirement.Snapshot.Data.Migrations;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDataConfiguration(config);
    })
    .Build();

var context = host.Services.GetService<RetirementSnapshotDbContext>() ?? throw new ArgumentNullException(nameof(RetirementSnapshotDbContext));
var fakeDataManager = new FakeDataManager(context);

await context.Database.MigrateAsync();
await fakeDataManager.SeedDataAsync();