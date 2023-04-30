using KamaFi.Retirement.Snapshot.Domain.Entities.User;
using KamaFi.Retirement.Snapshot.Application.Factories.Interfaces;
using KamaFi.Retirement.Snapshot.Application.Repositories.Interfaces;

namespace KamaFi.Retirement.Snapshot.Infrastructure.Repositories
{
    public class UserRepository : CosmosDbRepository<UserEntity>, IUserRepository
    {
        public override string ContainerName { get; } = "user-event-store";

        public UserRepository(ICosmosDbFactory factory)
            : base(factory) { }
    }
}
