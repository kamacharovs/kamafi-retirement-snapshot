using MediatR;

namespace KamaFi.Retirement.Snapshot.Common.Events.Domain
{
    public abstract class DomainEventBase : INotification
    {
        public string Id { get; protected set; } = Guid.NewGuid().ToString();
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
