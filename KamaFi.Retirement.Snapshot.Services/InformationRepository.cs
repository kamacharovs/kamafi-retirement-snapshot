using KamaFi.Retirement.Snapshot.Calculators;
using KamaFi.Retirement.Snapshot.Data.TransferObjects;

namespace KamaFi.Retirement.Snapshot.Services
{
    public interface IInformationRepository
    {
        public IEnumerable<StartingEarlyEntry> GetAdvantageOfStartingEarly();
    }

    public class InformationRepository : IInformationRepository
    {
        public IEnumerable<StartingEarlyEntry> GetAdvantageOfStartingEarly() 
        {
            var defaultInterest = 7;
            var defaultPresentValue = 0;
            var defaultPayments = 6000;
            var defaultCompoundingPeriods = 1;

            var result = new List<StartingEarlyEntry>
            {
                new StartingEarlyEntry
                {
                    Years = 0,
                    Interest = defaultInterest,
                    PresentValue = defaultPresentValue,
                    Payments = defaultPayments,
                    CompoundingPeriods = defaultCompoundingPeriods
                },
                new StartingEarlyEntry
                {
                    Years = 5,
                    Interest = defaultInterest,
                    PresentValue = defaultPresentValue,
                    Payments = defaultPayments,
                    CompoundingPeriods = defaultCompoundingPeriods
                },
                new StartingEarlyEntry
                {
                    Years = 15,
                    Interest = defaultInterest,
                    PresentValue = defaultPresentValue,
                    Payments = defaultPayments,
                    CompoundingPeriods = defaultCompoundingPeriods
                },
                new StartingEarlyEntry
                {
                    Years = 25,
                    Interest = defaultInterest,
                    PresentValue = defaultPresentValue,
                    Payments = defaultPayments,
                    CompoundingPeriods = defaultCompoundingPeriods
                },
                new StartingEarlyEntry
                {
                    Years = 35,
                    Interest = defaultInterest,
                    PresentValue = defaultPresentValue,
                    Payments = defaultPayments,
                    CompoundingPeriods = defaultCompoundingPeriods
                },
            };

            foreach (var see in result)
            {
                see.Amount = FinancialCalculator.FutureValue(
                    see.PresentValue,
                    see.Interest,
                    see.Years,
                    see.Payments,
                    see.CompoundingPeriods);
            }

            return result;
        }
    }
}
