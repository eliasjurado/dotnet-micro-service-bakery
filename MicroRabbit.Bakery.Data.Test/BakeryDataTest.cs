using Calculations.Test;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Xunit;

namespace MicroRabbit.Bakery.Data.Test
{
    public class BakeryDataTest
    {
        private readonly IOptions<ProductSetting> _appSettings;

        [Theory]
        [AvailableButterStockData]
        public void AvailableButterStock_IsEnoughButter(Product data, float value, bool expected)
        {
            var mockOptions = new DbContextOptionsBuilder<BakeryDbContext>()
                .UseInMemoryDatabase(databaseName: "BakeryDB")
                .Options;
            var mockContext = new BakeryDbContext(mockOptions);
            var exists = mockContext.Product.Find(data.Id);
            if (exists == null)
            {
                mockContext.Product.Add(data);
            }
            mockContext.SaveChanges();
            var mockRepository = new BakeryRepository(mockContext, _appSettings);

            var result = mockRepository.AvailableButterStock(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [AvailableFlourStockData]
        public void AvailableFlourStock_IsEnoughFlour(Product data, float value, bool expected)
        {
            var mockOptions = new DbContextOptionsBuilder<BakeryDbContext>()
                .UseInMemoryDatabase(databaseName: "BakeryDB")
                .Options;
            var mockContext = new BakeryDbContext(mockOptions);
            var exists = mockContext.Product.Find(data.Id);
            if (exists == null)
            {
                mockContext.Product.Add(data);
            }
            mockContext.SaveChanges();
            var mockRepository = new BakeryRepository(mockContext, _appSettings);

            var result = mockRepository.AvailableFlourStock(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ConsumingInventoryDataAttribute]
        public async Task ConsumingInventoryAsync_RemovesStockFromFlourAndButter(Product butter, Product flour, float projectedFlour, float projectedButter, int expectedFlourBalance, int expectedButterBalance)
        {
            var mockOptions = new DbContextOptionsBuilder<BakeryDbContext>()
                .UseInMemoryDatabase(databaseName: "BakeryDB")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var mockContext = new BakeryDbContext(mockOptions, _appSettings);

            var butterExists = mockContext.Product.Find(butter.Id);
            if (butterExists == null)
            {
                mockContext.Product.Add(butter);
            }
            mockContext.SaveChanges();

            var flourExists = mockContext.Product.Find(flour.Id);
            if (flourExists == null)
            {
                mockContext.Product.Add(flour);
            }
            mockContext.SaveChanges();

            var mockRepository = new BakeryRepository(mockContext);
            var cancellationTokenSource = new CancellationTokenSource(1000);

            await mockRepository.ConsumingInventoryAsync(projectedFlour, projectedButter, cancellationTokenSource.Token);
            var resultButterBalance = mockContext.Product.Find(3).Stock;
            var resultFlourBalance = mockContext.Product.Find(2).Stock;

            Assert.Equal(expectedButterBalance, resultButterBalance);
            Assert.Equal(expectedFlourBalance, resultFlourBalance);
        }
        //[Theory]
        //public async Task RegisterProductionAsync(float amount, DateTime expirationDate)
        //{

        //}
    }
}