using KamaFi.Retirement.Snapshot.Common.Entities;
using KamaFi.Retirement.Snapshot.Common.Interfaces;
using KamaFi.Retirement.Snapshot.Domain.Events.Assets;
using System;

namespace KamaFi.Retirement.Snapshot.Domain.Entities
{
    public class User : EntityBase, IAggregateRoot
    {
        private readonly List<Asset> _assets = new();

        private readonly List<Liability> _liabilities = new();

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private set; }
        public IEnumerable<Asset> Assets => _assets.AsReadOnly();
        public IEnumerable<Liability> Liabilities => _liabilities.AsReadOnly();

        public void AddAsset(Asset asset)
        {
            //Guard.Against.Null(newItem, nameof(newItem));
            _assets.Add(asset);

            var assetCreatedEvent = new AssetCreatedEvent();

            base.RegisterDomainEvent(assetCreatedEvent);
        }
    }
}
