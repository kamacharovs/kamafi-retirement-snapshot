using KamaFi.Retirement.Snapshot.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaFi.Retirement.Snapshot.Data.Responses
{
    public class RetirementCalculatorResponse
    {
        public int YearsInRetirement { get; set; }
        public double AmountAtRetirementAge { get; set; }
        public double AmountNeededAtRetirementAget { get; set; }

        public RetirementCalculatorRequest? Request { get; set; }
    }
}
