using KamaFi.Retirement.Snapshot.Domain.Entities.User;
using MediatR;

namespace KamaFi.Retirement.Snapshot.Application.Queries
{
    public class GetUserByIdQuery : IRequest<UserEntity>
    {
        public string Id { get; set; }

        public GetUserByIdQuery(string id)
        {
            Id = id;
        }
    }
}
