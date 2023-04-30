using KamaFi.Retirement.Snapshot.Application.Repositories.Interfaces;
using KamaFi.Retirement.Snapshot.Domain.Entities.User;
using MediatR;

namespace KamaFi.Retirement.Snapshot.Application.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserEntity>
    {
        private readonly IUserRepository _repo;

        public GetUserByIdQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetAsync(request.Id);

            return user ?? throw new Exception("Not Found");
        }
    }
}
