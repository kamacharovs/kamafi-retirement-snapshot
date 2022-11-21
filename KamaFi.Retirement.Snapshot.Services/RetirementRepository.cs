using KamaFi.Retirement.Snapshot.Data.Requests;
using KamaFi.Retirement.Snapshot.Data.Responses;
using KamaFi.Retirement.Snapshot.Calculators;
using Microsoft.Extensions.Logging;
using KamaFi.Retirement.Snapshot.Data.Exceptions;

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

            if (yearsInRetirement <= 0) throw new KamaFiBadRequestException("Years in retirement cannot be less than or equal to 0");
            if (yearsUntilRetirement < 0) throw new KamaFiBadRequestException("Years until retirement cannot be less than 0");

            var futureValueOfSavings = FinancialCalculator.FutureValue(
                presentValue: request.SavingsTotal,
                interestRate: request.InvestmentRateOfReturn,
                numberOfPeriods: yearsUntilRetirement,
                payments: request.SavingsMonthly);
            var amountNeededAtRetirementAge = yearsInRetirement * 12 * request.RetirementSpendingMonthly;

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
