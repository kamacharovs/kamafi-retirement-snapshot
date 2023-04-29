using KamaFi.Retirement.Snapshot.Common.Interfaces;

namespace KamaFi.Retirement.Snapshot.Infrastructure.Repositories.Interfaces
{
    public interface ICosmosDbRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
    }
}
