using KamaFi.Retirement.Snapshot.Common.Events.Domain;

namespace KamaFi.Retirement.Snapshot.Domain.Events.Asset
{
    public class AssetValueUpdatedEvent : DomainEventBase
    {
        public decimal Value { get; set; }

        public AssetValueUpdatedEvent(
            string id,
            decimal value)
        {
            Id = id;
            Value = value;
        }
    }
}
