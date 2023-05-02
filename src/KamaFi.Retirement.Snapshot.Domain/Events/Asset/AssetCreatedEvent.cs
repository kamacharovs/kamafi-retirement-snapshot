using KamaFi.Retirement.Snapshot.Common.Events.Domain;
using KamaFi.Retirement.Snapshot.Domain.Entities.Asset;

namespace KamaFi.Retirement.Snapshot.Domain.Events.Asset
{
    public class AssetCreatedEvent : DomainEventBase
    {
        public AssetEntity Asset { get; set; }

        public AssetCreatedEvent(
            AssetEntity asset)
        {
            Asset = asset;
        }
    }
}
