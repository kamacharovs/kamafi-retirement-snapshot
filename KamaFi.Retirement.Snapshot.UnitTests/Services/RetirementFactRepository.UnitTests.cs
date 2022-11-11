using Microsoft.Extensions.Logging;
using KamaFi.Retirement.Snapshot.Services;
using NSubstitute;
using FluentAssertions;
using KamaFi.Retirement.Snapshot.Data.Requests;

namespace KamaFi.Retirement.Snapshot.UnitTests.Services
{
    public class RetirementFactRepositoryUnitTests
    {
        [Fact]
        public async Task GetAsync_GivenNoRetirementFactsInDb_ShouldBeEmpty()
        {
            // Arrange
            var factory = new DatabaseFactory();
            var context = factory.CreateContextForSQLite();
            var repo = new RetirementFactRepository(Substitute.For<ILogger<RetirementFactRepository>>(), context);

            // Act
            var act = await repo.GetAsync();

            // Assert
            act.Should().NotBeNull();
            act.Should().BeEmpty();
        }

        [Theory]
        [InlineData("short 1")]
        [InlineData("short 2")]
        public async Task AddAsync_GivenValidRequest_ShouldBeSuccessful(string shortDescrption)
        {
            // Arrange
            var factory = new DatabaseFactory();
            var context = factory.CreateContextForSQLite();
            var repo = new RetirementFactRepository(Substitute.For<ILogger<RetirementFactRepository>>(), context);
            var request = new RetirementFactAddRequest
            {
                ShortDescription = shortDescrption,
                LongDescription = "I am long description",
                Year = 2022,
                Key = "roth_ira",
                Value = "6000"
            };

            // Act
            var act = await repo.AddAsync(request);

            // Assert
            act.Should().NotBeNull();
            act.RetirementFactId.Should().NotBe(0);
            act.PublicKey.Should().NotBe(Guid.Empty);
            act.ShortDescription.Should().Be(request.ShortDescription);
            act.LongDescription.Should().Be(request.LongDescription);
            act.Year.Should().Be(request.Year);
            act.Key.Should().Be(request.Key);
            act.Value.Should().Be(request.Value);
        }
    }
}
