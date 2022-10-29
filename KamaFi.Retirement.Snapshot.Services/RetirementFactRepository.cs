using KamaFi.Retirement.Snapshot.Data;
using KamaFi.Retirement.Snapshot.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KamaFi.Retirement.Snapshot.Services
{
    public interface IRetirementFactRepository
    {
        Task<IEnumerable<RetirementFact>> GetAsync();
    }

    public class RetirementFactRepository : IRetirementFactRepository
    {
        private readonly ILogger<RetirementFactRepository> _logger;
        private readonly RetirementSnapshotDbContext _context;

        public RetirementFactRepository(
            ILogger<RetirementFactRepository> logger,
            RetirementSnapshotDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<RetirementFact>> GetAsync()
        {
            return await _context.RetirementFacts
                .ToListAsync();
        }
    }
}