using System.Text.Json.Serialization;

namespace KamaFi.Retirement.Snapshot.Application.Requests.Asset
{
    public class UpdateAssetRequest
    {
        [JsonPropertyName("value")]
        public decimal? Value { get; set; }
    }
}
