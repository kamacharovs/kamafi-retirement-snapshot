using KamaFi.Retirement.Snapshot.Calculators;
using KamaFi.Retirement.Snapshot.Data.TransferObjects;

namespace KamaFi.Retirement.Snapshot.Services
{
    public interface IInformationRepository
    {
        public IEnumerable<StartingEarlyEntry> GetAdvantageOfStartingEarly();
        public IEnumerable<StartingEarlyEntry> GetAdvantageOfStartingEarly(IEnumerable<StartingEarlyEntry> entries);
    }

    public class InformationRepository : IInformationRepository
    {
        private readonly double _defaultInterest;
        private readonly double _defaultPresentValue;
        private readonly double _defaultPayments;
        private readonly int _defaultCompoundingPeriods;

        public InformationRepository()
        {
            _defaultInterest = 7;
            _defaultPresentValue = 0;
            _defaultPayments = 6000;
            _defaultCompoundingPeriods = 1;
        }

        public IEnumerable<StartingEarlyEntry> GetAdvantageOfStartingEarly()
        {
            var result = new List<StartingEarlyEntry>
            {
                new StartingEarlyEntry
                {
                    Years = 0,
                    Interest = _defaultInterest,
                    PresentValue = _defaultPresentValue,
                    Payments = _defaultPayments,
                    CompoundingPeriods = _defaultCompoundingPeriods
                },
                new StartingEarlyEntry
                {
                    Years = 5,
                    Interest = _defaultInterest,
                    PresentValue = _defaultPresentValue,
                    Payments = _defaultPayments,
                    CompoundingPeriods = _defaultCompoundingPeriods
                },
                new StartingEarlyEntry
                {
                    Years = 15,
                    Interest = _defaultInterest,
                    PresentValue = _defaultPresentValue,
                    Payments = _defaultPayments,
                    CompoundingPeriods = _defaultCompoundingPeriods
                },
                new StartingEarlyEntry
                {
                    Years = 25,
                    Interest = _defaultInterest,
                    PresentValue = _defaultPresentValue,
                    Payments = _defaultPayments,
                    CompoundingPeriods = _defaultCompoundingPeriods
                },
                new StartingEarlyEntry
                {
                    Years = 35,
                    Interest = _defaultInterest,
                    PresentValue = _defaultPresentValue,
                    Payments = _defaultPayments,
                    CompoundingPeriods = _defaultCompoundingPeriods
                },
            };

            return GetFutureValue(result);
        }

        public IEnumerable<StartingEarlyEntry> GetAdvantageOfStartingEarly(IEnumerable<StartingEarlyEntry> entries)
        {
            return GetFutureValue(entries);
        }

        private IEnumerable<StartingEarlyEntry> GetFutureValue(IEnumerable<StartingEarlyEntry> entries)
        {
            foreach (var entry in entries)
            {
                entry.Amount = FinancialCalculator.FutureValue(
                    entry.PresentValue,
                    entry.Interest,
                    entry.Years,
                    entry.Payments,
                    entry.CompoundingPeriods);
            }

            return entries;
        }
    }
}
