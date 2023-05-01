using KamaFi.Retirement.Snapshot.Application.Requests.Asset;
using KamaFi.Retirement.Snapshot.Application.Requests.Liability;
using KamaFi.Retirement.Snapshot.Application.Responses.Liability;
using MediatR;

namespace KamaFi.Retirement.Snapshot.Application.Commands
{
    public sealed record CreateLiabilityCommand(CreateLiabilityRequest Request) : IRequest<CreateLiabilityResponse>;
}
