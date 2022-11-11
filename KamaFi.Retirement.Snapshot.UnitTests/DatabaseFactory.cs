using KamaFi.Retirement.Snapshot.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace KamaFi.Retirement.Snapshot.UnitTests
{
    public class DatabaseFactory
    {
        private bool DisposedValue = false;

        public RetirementSnapshotDbContext CreateContextForSQLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<RetirementSnapshotDbContext>()
                .UseSqlite(connection).Options;

            var context = new RetirementSnapshotDbContext(option);

            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context!;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!DisposedValue)
            {
                if (disposing)
                {
                }

                DisposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
