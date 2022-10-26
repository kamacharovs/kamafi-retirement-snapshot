namespace KamaFi.Retirement.Snapshot.Calculators
{
    public static class FinancialCalculator
    {
        /// <summary>
        /// Calculates the future value of a present value
        /// </summary>
        /// <param name="presentValue">The present value. The initial balance of your investment</param>
        /// <param name="interestRate">Interest rate expressed on an annual basis. For example, 5.25%</param>
        /// <param name="numberOfPeriods">The number of periods, in years, the money is invested for. For example, 5</param>
        /// <param name="compoundingPeriods">The compounding frequency. The number of times the interest is compounded per year. Defaults to 12</param>
        /// <param name="roundingPlaces">The rounding places of the future value. Defaults to 2</param>
        /// <returns></returns>
        public static double FutureValue(
            double presentValue,
            double interestRate,
            double numberOfPeriods,
            int compoundingPeriods = 12,
            int roundingPlaces = 2)
        {
            var interest = interestRate / 100;

            return Math.Round(presentValue * Math.Pow((1 + interest / compoundingPeriods), numberOfPeriods * compoundingPeriods), roundingPlaces);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interestRate"></param>
        /// <param name="numberOfPeriods"></param>
        /// <param name="payments"></param>
        /// <param name="roundingPlaces"></param>
        /// <returns></returns>
        public static double FutureValueWithPayments(
            double interestRate,
            double numberOfPeriods,
            double payments,
            int roundingPlaces = 2)
        {
            var interest = interestRate / 100;

            return Math.Round(payments * ((Math.Pow(1 + interest, numberOfPeriods) - 1) / interest), roundingPlaces);
        }
    }
}