using KamaFi.Retirement.Snapshot.Common.Interfaces;
using KamaFi.Retirement.Snapshot.Application.Factories.Interfaces;
using KamaFi.Retirement.Snapshot.Application.Repositories.Interfaces;
using Microsoft.Azure.Cosmos;

namespace KamaFi.Retirement.Snapshot.Infrastructure.Repositories
{
    public abstract class CosmosDbRepository<T> : ICosmosDbRepository<T> where T : class, IAggregateRoot
    {
        private readonly ICosmosDbFactory _factory;
        private readonly Container _container;

        public abstract string ContainerName { get; }

        public CosmosDbRepository(ICosmosDbFactory factory)
        {
            _factory = factory;
            _container = _factory.GetContainer(ContainerName);
        }

        public async Task<T?> GetAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<T>(id, new PartitionKey(id));

                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.Id = Guid.NewGuid().ToString();

            var response = await _container.CreateItemAsync<T>(entity, new PartitionKey(entity.Id));

            return response;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var response = await _container.UpsertItemAsync<T>(entity, new PartitionKey(entity.Id));

            return response;
        }
    }
}
