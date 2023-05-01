using KamaFi.Retirement.Snapshot.Common.Entities;
using System.Text.Json.Serialization;

namespace KamaFi.Retirement.Snapshot.Domain.Entities.Liability
{
    public class LiabilityEntity : EntityBase
    {
        [JsonInclude]
        public string? Name { get; init; }

        [JsonInclude]
        public string? Type { get; init; }

        [JsonInclude]
        public decimal Value { get; init; }

        [JsonInclude]
        public string? UserId { get; init; }
    }
}
