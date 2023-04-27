using KamaFi.Retirement.Snapshot.Domain.Events.Asset;
using MediatR;

namespace KamaFi.Retirement.Snapshot.Application.Events.Handlers.Asset
{
    public class AssetCreatedEventHandler : INotificationHandler<AssetCreatedEvent>
    {
        public AssetCreatedEventHandler()
        {
            // Inject repo   
        }

        public async Task Handle(AssetCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
        }
    }
}
