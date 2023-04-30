using KamaFi.Retirement.Snapshot.Application.Responses.Asset;
using KamaFi.Retirement.Snapshot.Common.Interfaces;
using KamaFi.Retirement.Snapshot.Domain.Aggregates;
using KamaFi.Retirement.Snapshot.Domain.Entities.Asset;
using MediatR;
using KamaFi.Retirement.Snapshot.Common.Entities;
using KamaFi.Retirement.Snapshot.Application.Repositories.Interfaces;

namespace KamaFi.Retirement.Snapshot.Application.Commands.Handlers
{
    public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, CreateAssetResponse>
    {
        private readonly IUserRepository _repo;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public CreateAssetCommandHandler(
            IUserRepository repo,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _repo = repo;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task<CreateAssetResponse> Handle(CreateAssetCommand command, CancellationToken cancellationToken)
        {
            var request = command.Request;

            if (request.UserId == null) throw new Exception("Not found");

            var user = await _repo.GetAsync(request.UserId!);
            var userAggregate = new UserAggregate(user);
            var assetEntity = new AssetEntity
            {
                Name = request.Name,
                Type = request.Type,
                Value = request.Value,
                UserId = request.UserId
            };

            // This will create a domain event
            userAggregate.CreateAsset(assetEntity);

            var updatedUser = await _repo.AddAsync(userAggregate.User);
            var entitiesWithEvents = new List<EntityBase> { userAggregate.User };

            // In CosmosDB ES environment
            // 1. Create the event (EventSourceService.Create())
            // 2. Dispatch Domain Events (what to do when a domain entity has changed?) In our case, send message to EventHub
            await _domainEventDispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return new CreateAssetResponse
            {
                Id = "t"
            };
        }
    }
}
