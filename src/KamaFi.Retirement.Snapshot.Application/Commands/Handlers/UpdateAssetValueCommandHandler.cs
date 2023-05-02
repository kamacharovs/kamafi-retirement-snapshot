using KamaFi.Retirement.Snapshot.Common.Interfaces;
using KamaFi.Retirement.Snapshot.Domain.Aggregates;
using MediatR;
using KamaFi.Retirement.Snapshot.Common.Entities;
using KamaFi.Retirement.Snapshot.Application.Repositories.Interfaces;
using KamaFi.Retirement.Snapshot.Application.Responses.Asset;

namespace KamaFi.Retirement.Snapshot.Application.Commands.Handlers
{
    public class UpdateAssetValueCommandHandler : IRequestHandler<UpdateAssetValueCommand, UpdateAssetResponse>
    {
        private readonly IUserRepository _repo;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public UpdateAssetValueCommandHandler(
            IUserRepository repo,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _repo = repo;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task<UpdateAssetResponse> Handle(UpdateAssetValueCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            var assetId = request.AssetId;
            var assetValue = request.Request.Value;

            if (userId == null) throw new Exception("Not found");
            if (assetValue == null) throw new Exception("Asset value is null");

            var user = await _repo.GetAsync(userId);
            var userAggregate = new UserAggregate(user!);
            var updatedAsset = userAggregate.UpdateAssetValue(assetId, assetValue.Value);
            var updatedUser = await _repo.UpdateAsync(userAggregate.User);
            var entitiesWithEvents = new List<EntityBase> { updatedUser };

            await _domainEventDispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return new UpdateAssetResponse
            {
                Id = updatedAsset.Id,
                Name = updatedAsset.Name,
                Type = updatedAsset.Type,
                Value = updatedAsset.Value,
                UserId = updatedAsset.UserId
            };
        }
    }
}
