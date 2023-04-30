using KamaFi.Retirement.Snapshot.Common.Settings;
using KamaFi.Retirement.Snapshot.Application.Factories.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace KamaFi.Retirement.Snapshot.Infrastructure.Factories
{
    public class CosmosDbFactory : ICosmosDbFactory
    {
        private readonly CosmosDbSettings _settings;
        private readonly CosmosClient _client;

        public CosmosDbFactory(IOptions<CosmosDbSettings> options)
        {
            _settings = options.Value;
            _client = new CosmosClient(_settings.ConnectionString,
                new CosmosClientOptions
                {
                    SerializerOptions = new CosmosSerializationOptions
                    {
                        PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                    }
                });
        }

        private Database GetDatabase(string? databaseName = null) => _client.GetDatabase(databaseName ?? _settings.DatabaseName);

        public Container GetContainer(string containerName, string? databaseName = null) => GetDatabase(databaseName).GetContainer(containerName);
    }
}
