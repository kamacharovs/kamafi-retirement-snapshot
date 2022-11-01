using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaFi.Retirement.Snapshot.Data.TransferObjects
{
    public class StartingEarlyEntry
    {
        public int Years { get; set; }
        public double Interest { get; set; } = 7;
        public double PresentValue { get; set; } = 0;
        public double Payments { get; set; } = 500;
        public int CompoundingPeriods { get; set; } = 12;
        public double Amount { get; set; } = 0;
    }
}
