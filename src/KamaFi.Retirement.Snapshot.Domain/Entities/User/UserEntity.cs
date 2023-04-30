using KamaFi.Retirement.Snapshot.Common.Entities;
using KamaFi.Retirement.Snapshot.Common.Interfaces;
using KamaFi.Retirement.Snapshot.Domain.Entities.Asset;
using KamaFi.Retirement.Snapshot.Domain.Entities.Liability;
using KamaFi.Retirement.Snapshot.Domain.Events.Asset;

namespace KamaFi.Retirement.Snapshot.Domain.Entities.User
{
    public class UserEntity : EntityBase, IAggregateRoot
    {
        private readonly List<AssetEntity> _assets = new();

        private readonly List<LiabilityEntity> _liabilities = new();

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private set; }
        public IEnumerable<AssetEntity> Assets => _assets.AsReadOnly();
        public IEnumerable<LiabilityEntity> Liabilities => _liabilities.AsReadOnly();

        public void CreateAsset(AssetEntity asset)
        {
            //Guard.Against.Null(newItem, nameof(newItem));
            _assets.Add(asset);

            var assetCreatedEvent = new AssetCreatedEvent();

            base.RegisterDomainEvent(assetCreatedEvent);
        }
    }
}
