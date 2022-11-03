using KamaFi.Retirement.Snapshot.Data.Models;

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
                },
                new RetirementFact
                {
                    RetirementFactId = 5,
                    PublicKey = Guid.NewGuid(),
                    ShortDescription = "Americans retirement savings",
                    LongDescription = "Only half of Americans have calculated how much they need to save for retirement",
                    Year = 2022,
                    Key = "retirement_savings_americans",
                    Value = null,
                    Group = "general",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                },
                new RetirementFact
                {
                    RetirementFactId = 6,
                    PublicKey = Guid.NewGuid(),
                    ShortDescription = "People don't participate in 401(k)",
                    LongDescription = "In 2020, more than a quarter of private industry workers with access to a defined contribution plan (such as a 401(k) plan) did not participate",
                    Year = 2020,
                    Key = "401k_participation",
                    Value = null,
                    Group = "general",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                },
                new RetirementFact
                {
                    RetirementFactId = 7,
                    PublicKey = Guid.NewGuid(),
                    ShortDescription = "Time spent in retirement",
                    LongDescription = "The average American spends roughly 20 years in retirement",
                    Year = 2020,
                    Key = "time_in_retirement",
                    Value = null,
                    Group = "general",
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
