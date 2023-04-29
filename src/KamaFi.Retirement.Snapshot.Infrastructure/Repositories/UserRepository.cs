using KamaFi.Retirement.Snapshot.Domain.Entities.User;
using KamaFi.Retirement.Snapshot.Infrastructure.Factories.Interfaces;
using KamaFi.Retirement.Snapshot.Infrastructure.Repositories.Interfaces;

namespace KamaFi.Retirement.Snapshot.Infrastructure.Repositories
{
    public class UserRepository : CosmosDbRepository<UserEntity>, IUserRepository
    {
        public override string ContainerName { get; } = "changefeed";

        public UserRepository(ICosmosDbFactory factory)
            : base(factory) { }

        public async Task<UserEntity?> GetAsync(string id)
        {
            return await base.GetAsync(id);
        }

        public async Task<UserEntity> AddAsync(UserEntity entity)
        {
            return await base.AddAsync(entity);
        }
    }
}
