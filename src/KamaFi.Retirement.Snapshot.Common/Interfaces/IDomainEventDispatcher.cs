using KamaFi.Retirement.Snapshot.Common.Entities;

namespace KamaFi.Retirement.Snapshot.Common.Interfaces
{
    public interface IDomainEventDispatcher
    {
        public Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents);
    }
}
