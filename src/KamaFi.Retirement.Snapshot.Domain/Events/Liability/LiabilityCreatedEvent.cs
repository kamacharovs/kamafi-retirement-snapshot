using KamaFi.Retirement.Snapshot.Common.Events.Domain;
using KamaFi.Retirement.Snapshot.Domain.Entities.Liability;

namespace KamaFi.Retirement.Snapshot.Domain.Events.Liability
{
    public class LiabilityCreatedEvent : DomainEventBase
    {
        public LiabilityEntity Liability { get; set; }

        public LiabilityCreatedEvent(
            LiabilityEntity liability)
        {
            Liability = liability;
        }
    }
}
