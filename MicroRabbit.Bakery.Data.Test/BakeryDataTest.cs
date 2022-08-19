using MicroRabbit.Bakery.Data.Test.Data;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Data.Test.Fixture;
using MicroRabbit.Banking.Domain.Models;
using Xunit;
using Xunit.Abstractions;

namespace MicroRabbit.Bakery.Data.Test
{
    public class BakeryDataTest : IClassFixture<BakeryDataFixture>
    {
        public readonly ITestOutputHelper _testOutputHelper;
        public readonly BakeryDataFixture _bakeryDataFixture;

        public BakeryDataTest(ITestOutputHelper testOutputHelper, BakeryDataFixture bakeryDataFixture)
        {
            _testOutputHelper = testOutputHelper;
            _bakeryDataFixture = bakeryDataFixture;
        }

        [Theory]
        [AvailableButterStockData]
        public void AvailableButterStock_IsEnoughButter(Product data, float value, bool expected)
        {
            _testOutputHelper.WriteLine($"AvailableButterStock_IsEnoughButter - {DateTime.Now}");
            var mockSettings = _bakeryDataFixture.mockSettings;
            var mockOptions = _bakeryDataFixture.mockOptions;
            var mockContext = new BakeryDbContext(mockOptions);
            mockContext.Product.Add(data);
            mockContext.SaveChanges();
            var mockRepository = new BakeryRepository(mockContext, mockSettings);

            var result = mockRepository.AvailableButterStock(value);
            mockContext.Product.RemoveRange(mockContext.Product);
            mockContext.SaveChanges();

            Assert.Equal(expected, result);
        }

        [Theory]
        [AvailableFlourStockData]
        public void AvailableFlourStock_IsEnoughFlour(Product data, float value, bool expected)
        {
            _testOutputHelper.WriteLine($"AvailableFlourStock_IsEnoughFlour - {DateTime.Now}");
            var mockSettings = _bakeryDataFixture.mockSettings;
            var mockOptions = _bakeryDataFixture.mockOptions;
            var mockContext = new BakeryDbContext(mockOptions);
            mockContext.Product.Add(data);
            mockContext.SaveChanges();
            var mockRepository = new BakeryRepository(mockContext, mockSettings);

            var result = mockRepository.AvailableFlourStock(value);
            mockContext.Product.RemoveRange(mockContext.Product);
            mockContext.SaveChanges();

            Assert.Equal(expected, result);
        }

        [Theory]
        [ConsumingInventoryDataAttribute]
        public async Task ConsumingInventoryAsync_RemovesStockFromFlourAndButter(Product butter, Product flour, float projectedFlour, float projectedButter, int expectedFlourBalance, int expectedButterBalance)
        {
            _testOutputHelper.WriteLine($"ConsumingInventoryAsync_RemovesStockFromFlourAndButter - {DateTime.Now}");
            var mockSettings = _bakeryDataFixture.mockSettings;
            var mockOptions = _bakeryDataFixture.mockOptions;
            var mockContext = new BakeryDbContext(mockOptions);

            mockContext.Product.Add(butter);
            mockContext.Product.Add(flour);
            mockContext.SaveChanges();

            var mockRepository = new BakeryRepository(mockContext, mockSettings);
            var cancellationTokenSource = _bakeryDataFixture.cancellationTokenSource;

            await mockRepository.ConsumingInventoryAsync(projectedFlour, projectedButter, cancellationTokenSource.Token);
            var butterId = _bakeryDataFixture.mockSettings.Value.ButterId;
            var flourId = _bakeryDataFixture.mockSettings.Value.FlourId;
            var resultButterBalance = mockContext.Product.Find(butterId).Stock;
            var resultFlourBalance = mockContext.Product.Find(flourId).Stock;
            mockContext.Product.RemoveRange(mockContext.Product);
            mockContext.SaveChanges();

            Assert.Equal(expectedButterBalance, resultButterBalance);
            Assert.Equal(expectedFlourBalance, resultFlourBalance);
        }

        // [Theory]
        // public async Task RegisterProductionAsync(float amount, DateTime expirationDate)
        // {
        //     var mockOptions = new DbContextOptionsBuilder<BakeryDbContext>()
        //        .UseInMemoryDatabase(databaseName: "BakeryDB")
        //        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
        //        .Options;
        //     var mockContext = new BakeryDbContext(mockOptions);

        //     var butterExists = mockContext.Product.Find(butter.Id);
        //     if (butterExists == null)
        //     {
        //         mockContext.Product.Add(butter);
        //     }
        //     mockContext.SaveChanges();

        //     var flourExists = mockContext.Product.Find(flour.Id);
        //     if (flourExists == null)
        //     {
        //         mockContext.Product.Add(flour);
        //     }
        //     mockContext.SaveChanges();

        //     var mockRepository = new BakeryRepository(mockContext);
        //     var cancellationTokenSource = new CancellationTokenSource(1000);

        //     await mockRepository.ConsumingInventoryAsync(projectedFlour, projectedButter, cancellationTokenSource.Token);
        //     var resultButterBalance = mockContext.Product.Find(3).Stock;
        //     var resultFlourBalance = mockContext.Product.Find(2).Stock;

        //     Assert.Equal(expectedButterBalance, resultButterBalance);
        //     Assert.Equal(expectedFlourBalance, resultFlourBalance);
        // }
    }
}