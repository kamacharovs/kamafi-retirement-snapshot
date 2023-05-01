using KamaFi.Retirement.Snapshot.Common.Interfaces;
using KamaFi.Retirement.Snapshot.Domain.Aggregates;
using MediatR;
using KamaFi.Retirement.Snapshot.Common.Entities;
using KamaFi.Retirement.Snapshot.Application.Repositories.Interfaces;
using KamaFi.Retirement.Snapshot.Application.Responses.Liability;
using KamaFi.Retirement.Snapshot.Domain.Entities.Liability;

namespace KamaFi.Retirement.Snapshot.Application.Commands.Handlers
{
    public class CreateLiabilityCommandHandler : IRequestHandler<CreateLiabilityCommand, CreateLiabilityResponse>
    {
        private readonly IUserRepository _repo;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public CreateLiabilityCommandHandler(
            IUserRepository repo,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _repo = repo;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task<CreateLiabilityResponse> Handle(CreateLiabilityCommand command, CancellationToken cancellationToken)
        {
            var request = command.Request;

            if (request.UserId == null) throw new Exception("Not found");

            var user = await _repo.GetAsync(request.UserId!);
            var userAggregate = new UserAggregate(user);
            var liabilityEntity = new LiabilityEntity
            {
                Name = request.Name,
                Type = request.Type,
                Value = request.Value,
                UserId = request.UserId
            };

            // This will create a domain event
            userAggregate.CreateLiability(liabilityEntity);

            var updatedUser = await _repo.UpdateAsync(userAggregate.User);
            var entitiesWithEvents = new List<EntityBase> { updatedUser };

            // In CosmosDB ES environment
            // 1. Create the event (EventSourceService.Create())
            // 2. Dispatch Domain Events (what to do when a domain entity has changed?) In our case, send message to EventHub
            await _domainEventDispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return new CreateLiabilityResponse
            {
                Id = liabilityEntity.Id,
                Name = liabilityEntity.Name,
                Type = liabilityEntity.Type,
                Value = liabilityEntity.Value,
                UserId = liabilityEntity.UserId
            };
        }
    }
}
