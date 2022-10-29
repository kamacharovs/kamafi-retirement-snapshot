using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaFi.Retirement.Snapshot.Data.Options
{
    public class RetirementSnapshotOptions
    {
        public const string Section = "RetirementSnapshotDb";

        public string? Host { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? DatabaseName { get; set; }

        public string ConnectionString => $"Server={Host};Username={Username};Password={Password};Database={DatabaseName}";
    }
}
