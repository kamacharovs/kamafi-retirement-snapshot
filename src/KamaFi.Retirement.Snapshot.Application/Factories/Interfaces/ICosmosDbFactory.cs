using Microsoft.Azure.Cosmos;

namespace KamaFi.Retirement.Snapshot.Application.Factories.Interfaces
{
    public interface ICosmosDbFactory
    {
        Container GetContainer(string containerName, string? databaseName = null);
    }
}
