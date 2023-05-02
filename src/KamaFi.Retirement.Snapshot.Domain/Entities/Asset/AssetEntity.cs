using KamaFi.Retirement.Snapshot.Common.Entities;
using System.Text.Json.Serialization;

namespace KamaFi.Retirement.Snapshot.Domain.Entities.Asset
{
    public class AssetEntity : EntityBase
    {
        [JsonInclude]
        public string? Name { get; init; }

        [JsonInclude]
        public string? Type { get; init; }

        [JsonInclude]
        public decimal Value { get; set; }

        [JsonInclude]
        public string? UserId { get; init; }
    }
}
