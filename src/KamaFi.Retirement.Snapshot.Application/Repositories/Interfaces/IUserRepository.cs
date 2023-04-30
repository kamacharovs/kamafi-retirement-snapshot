using KamaFi.Retirement.Snapshot.Domain.Entities.User;

namespace KamaFi.Retirement.Snapshot.Application.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetAsync(string id);
        Task<UserEntity> AddAsync(UserEntity entity);
    }
}
