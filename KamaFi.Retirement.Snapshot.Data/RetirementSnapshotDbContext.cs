using KamaFi.Retirement.Snapshot.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KamaFi.Retirement.Snapshot.Data
{
    public class RetirementSnapshotDbContext : DbContext
    {
        public virtual DbSet<RetirementFact> RetirementFacts { get; set; }

        public RetirementSnapshotDbContext(DbContextOptions<RetirementSnapshotDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSnakeCaseNamingConvention();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RetirementFact>(e =>
            {
                e.ToTable("retirement_fact");

                e.HasKey(x => x.RetirementFactId);

                e.Property(x => x.RetirementFactId).ValueGeneratedOnAdd().IsRequired();
                e.Property(x => x.PublicKey).ValueGeneratedOnAdd().HasDefaultValueSql("gen_random_uuid()").IsRequired();
                e.Property(x => x.ShortDescription).HasMaxLength(200).IsRequired();
                e.Property(x => x.LongDescription).HasMaxLength(5000).IsRequired();
                e.Property(x => x.Key).HasMaxLength(100).IsRequired();
                e.Property(x => x.Value).HasMaxLength(500).IsRequired();
                e.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("current_timestamp").IsRequired();
                e.Property(x => x.UpdatedAt).ValueGeneratedOnAdd().ValueGeneratedOnUpdate().HasDefaultValueSql("current_timestamp").IsRequired();
            });
        }
    }
}