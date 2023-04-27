using KamaFi.Retirement.Snapshot.Common.Interfaces;
using KamaFi.Retirement.Snapshot.Domain.Entities.User;

namespace KamaFi.Retirement.Snapshot.Infrastructure.Repositories
{
    public class UserRepository : IRepository<UserEntity>
    {
        public UserRepository()
        {
            
        }

        public Task<UserEntity> GetAsync(string id)
        {
            return Task.FromResult(new UserEntity { Id = id });
        }

        public Task<UserEntity> UpdateAsync(UserEntity entity)
        {
            return Task.FromResult(entity);
        }
    }
}
