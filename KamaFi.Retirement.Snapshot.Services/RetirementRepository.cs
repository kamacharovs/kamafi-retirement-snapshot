using KamaFi.Retirement.Snapshot.Data.Requests;
using KamaFi.Retirement.Snapshot.Data.Responses;
using KamaFi.Retirement.Snapshot.Calculators;
using Microsoft.Extensions.Logging;

namespace KamaFi.Retirement.Snapshot.Services
{
    public interface IRetirementRepository
    {
        public RetirementCalculatorResponse RetirementCalculator(RetirementCalculatorRequest request);
    }

    public class RetirementRepository : IRetirementRepository
    {
        private readonly ILogger<RetirementRepository> _logger;

        public RetirementRepository(
            ILogger<RetirementRepository> logger)
        {
            _logger = logger;
        }

        public RetirementCalculatorResponse RetirementCalculator(RetirementCalculatorRequest request)
        {
            var yearsInRetirement = request.LifeExpectancy - request.RetirementAge;
            var yearsUntilRetirement = request.RetirementAge - request.Age;
            var futureValueOfSavings = FinancialCalculator.FutureValue(
                presentValue: request.SavingsTotal,
                interestRate: request.InvestmentRateOfReturn,
                numberOfPeriods: yearsUntilRetirement,
                payments: request.SavingsMonthly);
            var amountNeededAtRetirementAge = yearsInRetirement * 12 * request.RetirementSpendingMonthly;

            // TODO validations
            if (yearsInRetirement <= 0) { }

            var response = new RetirementCalculatorResponse
            {
                YearsInRetirement = yearsInRetirement,
                AmountAtRetirementAge = futureValueOfSavings,
                AmountNeededAtRetirementAge = amountNeededAtRetirementAge,
                Request = request
            };

            return response;
        }
    }
}
