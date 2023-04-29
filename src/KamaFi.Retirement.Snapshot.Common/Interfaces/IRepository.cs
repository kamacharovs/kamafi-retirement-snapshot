namespace KamaFi.Retirement.Snapshot.Common.Interfaces
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        public Task<T?> GetAsync(string id);
        public Task<T> AddAsync(T entity);
        //public Task<T> UpdateAsync(T entity);
    }
}
