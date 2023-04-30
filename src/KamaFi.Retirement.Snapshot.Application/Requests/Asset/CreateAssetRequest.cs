using System.Text.Json.Serialization;

namespace KamaFi.Retirement.Snapshot.Application.Requests.Asset
{
    public class CreateAssetRequest
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        [JsonPropertyName("userId")]
        public string? UserId { get; set; }
    }
}
