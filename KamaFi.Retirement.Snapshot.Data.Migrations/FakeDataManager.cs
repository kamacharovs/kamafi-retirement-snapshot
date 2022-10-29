using KamaFi.Retirement.Snapshot.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaFi.Retirement.Snapshot.Data.Migrations
{
    public class FakeDataManager
    {
        private readonly RetirementSnapshotDbContext _context;

        public FakeDataManager(RetirementSnapshotDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<RetirementFact> GetRetirementFacts()
        {
            return new List<RetirementFact>
            {
                new RetirementFact
                {
                    RetirementFactId = 1,
                    PublicKey = Guid.NewGuid(),
                    ShortDescription = "401(k) Contributions",
                    LongDescription = "How much can you contribute to your 401(k) per year",
                    Year = 2022,
                    Key = "401_k",
                    Value = "$20500",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                },
                new RetirementFact
                {
                    RetirementFactId = 2,
                    PublicKey = Guid.NewGuid(),
                    ShortDescription = "Roth IRA",
                    LongDescription = "How much can you contribute to your Roth IRA per year",
                    Year = 2022,
                    Key = "roth_ira",
                    Value = "$6500",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                },
                new RetirementFact
                {
                    RetirementFactId = 3,
                    PublicKey = Guid.NewGuid(),
                    ShortDescription = "Retirement age for men",
                    LongDescription = "Although this is a little more complicated, this is the retirement age for men",
                    Year = 2022,
                    Key = "retirement_age_men",
                    Value = "65",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                },
                new RetirementFact
                {
                    RetirementFactId = 4,
                    PublicKey = Guid.NewGuid(),
                    ShortDescription = "Retirement age for women",
                    LongDescription = "Although this is a little more complicated, this is the retirement age for women",
                    Year = 2022,
                    Key = "retirement_age_women",
                    Value = "65",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                }
            };
        }

        public async Task SeedDataAsync()
        {
            await _context.RetirementFacts.AddRangeAsync(GetRetirementFacts());

            await _context.SaveChangesAsync();
        }

        public void SeedData()
        {
            _context.RetirementFacts.AddRange(GetRetirementFacts());

            _context.SaveChanges();
        }
    }
}
