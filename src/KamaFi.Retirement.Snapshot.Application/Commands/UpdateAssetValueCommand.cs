using KamaFi.Retirement.Snapshot.Application.Requests.Asset;
using KamaFi.Retirement.Snapshot.Application.Responses.Asset;
using MediatR;

namespace KamaFi.Retirement.Snapshot.Application.Commands
{
    public sealed record UpdateAssetValueCommand(string UserId, string AssetId, UpdateAssetRequest Request) : IRequest<UpdateAssetResponse>;
}
