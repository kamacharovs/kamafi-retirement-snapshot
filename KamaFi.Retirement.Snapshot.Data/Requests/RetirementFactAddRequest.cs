namespace KamaFi.Retirement.Snapshot.Data.Requests
{
    public class RetirementFactAddRequest
    {
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public int Year { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? Group { get; set; }
    }
}
