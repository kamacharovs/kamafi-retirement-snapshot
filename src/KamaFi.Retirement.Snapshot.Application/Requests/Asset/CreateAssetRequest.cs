namespace KamaFi.Retirement.Snapshot.Application.Requests.Asset
{
    public class CreateAssetRequest
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public decimal Value { get; set; }
        public string? UserId { get; set; }
    }
}
