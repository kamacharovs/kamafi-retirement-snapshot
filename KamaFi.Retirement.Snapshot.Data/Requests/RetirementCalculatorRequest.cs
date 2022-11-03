namespace KamaFi.Retirement.Snapshot.Data.Requests
{
    public class RetirementCalculatorRequest
    {
        public int Age { get; set; } = 35;
        public double IncomePreTaxAnnual { get; set; } = 60000;
        public double SavingsTotal { get; set; } = 30000;
        public double SavingsMonthly { get; set; } = 500;

        // Optional
        public double RetirementSpendingMonthly { get; set; } = 2550;
        public double IncomeOther { get; set; } = 0;
        public int RetirementAge { get; set; } = 67;
        public int LifeExpectancy { get; set; } = 95;
        public double InvestmentRateOfReturn { get; set; } = 6;
    }
}
