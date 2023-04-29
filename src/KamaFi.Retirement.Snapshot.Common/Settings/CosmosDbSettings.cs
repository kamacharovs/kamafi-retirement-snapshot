namespace KamaFi.Retirement.Snapshot.Common.Settings
{
    public class CosmosDbSettings
    {
        public const string Section = nameof(CosmosDbSettings);

        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
    }
}
