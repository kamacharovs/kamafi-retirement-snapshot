using KamaFi.Retirement.Snapshot.Common.Entities;
using KamaFi.Retirement.Snapshot.Common.Interfaces;
using KamaFi.Retirement.Snapshot.Domain.Entities.Asset;
using KamaFi.Retirement.Snapshot.Domain.Entities.Liability;
using KamaFi.Retirement.Snapshot.Domain.Events.Asset;
using KamaFi.Retirement.Snapshot.Domain.Events.Liability;
using System.Text.Json.Serialization;

namespace KamaFi.Retirement.Snapshot.Domain.Entities.User
{
    public class UserEntity : EntityBase, IAggregateRoot
    {
        [JsonInclude]
        public string? FirstName { get; init; }

        [JsonInclude]
        public string? LastName { get; init; }

        [JsonInclude]
        public string? Email { get; init; }

        [JsonInclude]
        public List<AssetEntity> Assets { get; init; } = new List<AssetEntity>();

        [JsonInclude]
        public List<LiabilityEntity> Liabilities { get; init; } = new List<LiabilityEntity>();

        public void CreateAsset(AssetEntity asset)
        {
            Assets.Add(asset);

            var assetCreatedEvent = new AssetCreatedEvent(asset);

            base.RegisterDomainEvent(assetCreatedEvent);
        }

        public void CreateLiability(LiabilityEntity liability)
        {
            Liabilities.Add(liability);

            var assetCreatedEvent = new LiabilityCreatedEvent(liability);

            base.RegisterDomainEvent(assetCreatedEvent);
        }
    }
}
