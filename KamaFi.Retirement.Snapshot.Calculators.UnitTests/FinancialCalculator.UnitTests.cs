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

        [Fact]
        public void FutureValue_WithValidParameters_ShouldBeSuccesfulAndBeDifferentBasedOnPaymentDue()
        {
            // Arrange
            var presentValue = 500;
            var interestRate = 8;
            var numberOfPeriods = 12;
            var payments = 150;

            // Act
            var futureValueBeginningOfPeriod = FinancialCalculator.FutureValue(
                presentValue: presentValue,
                interestRate: interestRate,
                numberOfPeriods: numberOfPeriods,
                payments: payments,
                paymentDue: Excel.FinancialFunctions.PaymentDue.BeginningOfPeriod);

            var futureValueEndOfPeriodd = FinancialCalculator.FutureValue(
                presentValue: presentValue,
                interestRate: interestRate,
                numberOfPeriods: numberOfPeriods,
                payments: payments,
                paymentDue: Excel.FinancialFunctions.PaymentDue.EndOfPeriod);

            // Assert
            futureValueBeginningOfPeriod.Should().BeGreaterThan(0);
            futureValueEndOfPeriodd.Should().BeGreaterThan(0);
            futureValueBeginningOfPeriod.Should().NotBe(futureValueEndOfPeriodd);
            futureValueBeginningOfPeriod.Should().BeGreaterThan(futureValueEndOfPeriodd);
        }

        #region RothIraFutureValue
        [Theory]
        [InlineData(10.0, 8.0, 10, 500)]
        [InlineData(14879.12, 8.0, 10, 350)]
        [InlineData(50000.0, 8.0, 10, 100)]
        [InlineData(50028.0, 8.0, 10, 500, 3)]
        public void RothIraFutureValue_WithValidParameters_ShouldBeSuccesfulAndGreaterThanPresentValue(
            double presentValue,
            double interestRate,
            double years,
            double monthlyPayments,
            int roundingPlaces = 2)
        {
            // Act
            var act = FinancialCalculator.RothIraFutureValue(
                presentValue, 
                interestRate, 
                years,
                monthlyPayments,
                roundingPlaces: roundingPlaces);

            // Assert
            act.Should().BeGreaterThan(0);
            act.Should().BeGreaterThan(presentValue);
        }

        [Fact]
        public void RothIraFutureValue_WithValidParametersButNoContributions_ShouldBeSuccesfulAndGreaterThanPresentValue()
        {
            // Arrange
            var presentValue = 500;

            // Act
            var act = FinancialCalculator.RothIraFutureValue(presentValue, 8, 5,0);

            // Assert
            act.Should().BeGreaterThan(0);
            act.Should().BeGreaterThan(presentValue);
        }
        #endregion
    }
}