using KamaFi.Retirement.Snapshot.Data;
using KamaFi.Retirement.Snapshot.Data.Models;
using KamaFi.Retirement.Snapshot.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using KamaFi.Retirement.Snapshot.Data.Requests;

namespace KamaFi.Retirement.Snapshot.Services
{
    public interface IRetirementFactRepository
    {
        Task<IEnumerable<RetirementFact>> GetAsync();
        Task<RetirementFact> AddAsync(RetirementFactAddRequest request);
        Task DeleteAsync(int retirementFactId);
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

        private async Task<RetirementFact> GetAsync(int retirementFactId)
        {
            return await _context.RetirementFacts
                .FirstOrDefaultAsync(x => x.RetirementFactId == retirementFactId)
                ?? throw new KamaFiNotFoundException($"Retirement fact with RetirementFactId={retirementFactId} was not found");
        }

        public async Task<IEnumerable<RetirementFact>> GetAsync()
        {
            return await _context.RetirementFacts
                .OrderBy(x => x.Group)
                .ToListAsync();
        }

        public async Task<RetirementFact> AddAsync(RetirementFactAddRequest request)
        {
            var retirementFact = new RetirementFact(request);

            await _context.AddAsync(retirementFact);
            await _context.SaveChangesAsync();

            return retirementFact;
        }

        public async Task DeleteAsync(int retirementFactId)
        {
            var retirementFactInDb = await GetAsync(retirementFactId);

            _context.Remove(retirementFactInDb);

            await _context.SaveChangesAsync();
        }
    }
}