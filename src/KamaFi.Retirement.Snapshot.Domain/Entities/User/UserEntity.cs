using KamaFi.Retirement.Snapshot.Common.Entities;
using KamaFi.Retirement.Snapshot.Common.Interfaces;
using KamaFi.Retirement.Snapshot.Domain.Entities.Asset;
using KamaFi.Retirement.Snapshot.Domain.Entities.Liability;
using KamaFi.Retirement.Snapshot.Domain.Events.Asset;
using System.Text.Json.Serialization;

namespace KamaFi.Retirement.Snapshot.Domain.Entities.User
{
    public class UserEntity : EntityBase, IAggregateRoot
    {

        private readonly List<LiabilityEntity> _liabilities = new();

        [JsonInclude]
        public string? FirstName { get; init; }

        [JsonInclude]
        public string? LastName { get; init; }

        [JsonInclude]
        public string? Email { get; init; }

        [JsonInclude]
        public List<AssetEntity> Assets { get; init; } = new List<AssetEntity>();

        [JsonInclude]
        public IEnumerable<LiabilityEntity> Liabilities => _liabilities.AsReadOnly();

        public void CreateAsset(AssetEntity asset)
        {
            //Guard.Against.Null(newItem, nameof(newItem));
            Assets.Add(asset);

            var assetCreatedEvent = new AssetCreatedEvent();

            base.RegisterDomainEvent(assetCreatedEvent);
        }
    }
}
