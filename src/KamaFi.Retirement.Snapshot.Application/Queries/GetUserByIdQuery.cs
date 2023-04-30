using KamaFi.Retirement.Snapshot.Domain.Entities.User;
using MediatR;

namespace KamaFi.Retirement.Snapshot.Application.Queries
{
    public sealed record GetUserByIdQuery(string Id) : IRequest<UserEntity>;
}
