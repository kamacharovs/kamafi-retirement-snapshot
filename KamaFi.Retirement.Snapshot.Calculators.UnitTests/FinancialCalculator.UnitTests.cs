namespace KamaFi.Retirement.Snapshot.Calculators.UnitTests
{
    public class FinancialCalculatorUnitTests
    {
        [Theory]
        [InlineData(10.0, 8.0, 10)]
        [InlineData(14879.12, 8.0, 10)]
        [InlineData(50000.0, 8.0, 10)]
        [InlineData(50028.0, 8.0, 10, 3)]
        public void FutureValue_WithValidParametersAndNoPayments_ShouldBeSuccesfulAndGreaterThanPresentValue(
            double presentValue,
            double interestRate,
            double numberOfPeriods,
            int roundingPlaces = 2)
        {
            // Act
            var futureValue = FinancialCalculator.FutureValue(
                presentValue, 
                interestRate, 
                numberOfPeriods,
                roundingPlaces: roundingPlaces);

            // Assert
            futureValue.Should().BeGreaterThan(0);
            futureValue.Should().BeGreaterThan(presentValue);
        }

        [Theory]
        [InlineData(10.0, 8.0, 10, 500)]
        [InlineData(14879.12, 8.0, 10, 1000)]
        [InlineData(50000.0, 8.0, 10, 125)]
        [InlineData(50028.0, 8.0, 10, 1500)]
        public void FutureValueWithPayments_WithValidParametersAndPayments_ShouldBeSuccesfulAndGreaterThanPresentValue(
            double presentValue,
            double interestRate,
            double numberOfPeriods,
            double payments)
        {
            // Act
            var futureValue = FinancialCalculator.FutureValue(
                presentValue: presentValue,
                interestRate: interestRate,
                numberOfPeriods: numberOfPeriods,
                payments: payments);

            // Assert
            futureValue.Should().BeGreaterThan(0);
            futureValue.Should().BeGreaterThan(presentValue);
        }
    }
}