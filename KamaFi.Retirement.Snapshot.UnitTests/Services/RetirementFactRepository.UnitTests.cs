using Microsoft.Extensions.Logging;
using KamaFi.Retirement.Snapshot.Services;
using NSubstitute;
using FluentAssertions;
using KamaFi.Retirement.Snapshot.Data.Requests;
using KamaFi.Retirement.Snapshot.Data.Exceptions;

namespace KamaFi.Retirement.Snapshot.UnitTests.Services
{
    public class RetirementFactRepositoryUnitTests
    {
        private RetirementFactAddRequest GetRetirementFactAddRequest(
            string? shortDescription = null)
        {
            return new RetirementFactAddRequest
            {
                ShortDescription = shortDescription ?? "short",
                LongDescription = "I am long description",
                Year = 2022,
                Key = "roth_ira",
                Value = "6000"
            };
        }

        [Fact]
        public async Task GetAsync_GivenAFoundRetirementFactId_ShouldBeSuccessful()
        {
            // Arrange
            var factory = new DatabaseFactory();
            var context = factory.CreateContextForSQLite();
            var repo = new RetirementFactRepository(Substitute.For<ILogger<RetirementFactRepository>>(), context);
            var request = GetRetirementFactAddRequest();
            var retirementFactInDb = await repo.AddAsync(request);

            // Act
            var act = await repo.GetAsync(retirementFactInDb.RetirementFactId);

            // Assert
            act.Should().NotBeNull();
            act.ShortDescription.Should().Be(request.ShortDescription);
        }

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

        [Fact]
        public async Task GetAsync_GivenRetirementFactsInDb_ShouldReturnAllOrderedByGroup()
        {
            // Arrange
            var factory = new DatabaseFactory();
            var context = await factory.CreateContextForSQLite().WithSeedAsync();
            var repo = new RetirementFactRepository(Substitute.For<ILogger<RetirementFactRepository>>(), context);

            // Act
            var act = await repo.GetAsync();

            // Assert
            act.Should().NotBeNull();
            act.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("short 1")]
        [InlineData("short 2")]
        public async Task AddAsync_GivenValidRequest_ShouldBeSuccessful(string shortDescription)
        {
            // Arrange
            var factory = new DatabaseFactory();
            var context = factory.CreateContextForSQLite();
            var repo = new RetirementFactRepository(Substitute.For<ILogger<RetirementFactRepository>>(), context);
            var request = GetRetirementFactAddRequest(shortDescription);

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

        [Fact]
        public async Task DeleteAsync_GivenAFoundRetirementFactId_ShouldBeSuccessful()
        {
            // Arrange
            var factory = new DatabaseFactory();
            var context = factory.CreateContextForSQLite();
            var repo = new RetirementFactRepository(Substitute.For<ILogger<RetirementFactRepository>>(), context);
            var request = GetRetirementFactAddRequest();
            var retirementFactInDb = await repo.AddAsync(request);

            // Act
            await repo.DeleteAsync(retirementFactInDb.RetirementFactId);
            var act = async () => await repo.GetAsync(retirementFactInDb.RetirementFactId);

            // Assert
            await act.Should().ThrowAsync<KamaFiNotFoundException>();
        }
    }
}
