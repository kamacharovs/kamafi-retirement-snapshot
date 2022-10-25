using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaFi.Retirement.Snapshot.Data.Models
{
    public class RetirementFact
    {
        public int RetirementFactId { get; set; }
        public Guid PublicKey { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
