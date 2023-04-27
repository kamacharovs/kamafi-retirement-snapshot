using MediatR;

namespace KamaFi.Retirement.Snapshot.Common.Events.Domain
{
    public abstract class DomainEventBase : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
