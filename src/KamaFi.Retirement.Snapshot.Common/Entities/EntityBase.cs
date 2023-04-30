using KamaFi.Retirement.Snapshot.Common.Events.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KamaFi.Retirement.Snapshot.Common.Entities
{
    public abstract class EntityBase
    {
        private List<DomainEventBase> _domainEvents = new();

        public string Id { get; set; } = Guid.NewGuid().ToString();

        [NotMapped]
        [JsonIgnore]
        public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

        protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
        internal void ClearDomainEvents() => _domainEvents.Clear();
    }
}
