using KamaFi.Retirement.Snapshot.Data.Requests;

namespace KamaFi.Retirement.Snapshot.Data.Models
{
    public class RetirementFact
    {
        public int RetirementFactId { get; set; }
        public Guid PublicKey { get; set; } = Guid.NewGuid();
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public int Year { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? Group { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public RetirementFact() { }
        public RetirementFact(RetirementFactAddRequest request)
        {
            ShortDescription = request.ShortDescription;
            LongDescription = request.LongDescription;
            Year = request.Year;
            Key = request.Key;
            Value = request.Value;
            Group = request.Group;
        }
    }
}
