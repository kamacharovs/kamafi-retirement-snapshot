﻿using KamaFi.Retirement.Snapshot.Application.Commands;
using KamaFi.Retirement.Snapshot.Application.Responses.Asset;
using KamaFi.Retirement.Snapshot.Common.Interfaces;
using KamaFi.Retirement.Snapshot.Domain.Aggregates;
using KamaFi.Retirement.Snapshot.Domain.Entities.User;
using KamaFi.Retirement.Snapshot.Domain.Entities.Asset;
using MediatR;

namespace KamaFi.Retirement.Snapshot.Application.Commands.Handlers
{
    public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, CreateAssetResponse>
    {
        private readonly IRepository<UserEntity> _repo;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public CreateAssetCommandHandler(
            IRepository<UserEntity> repo,
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

            var updatedUser = await _repo.UpdateAsync(userAggregate.User);

            return new CreateAssetResponse
            {
                Id = "t"
            };
        }
    }
}