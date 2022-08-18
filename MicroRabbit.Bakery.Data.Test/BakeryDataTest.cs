using Calculations.Test;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
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
            var mockOptions = new DbContextOptionsBuilder<BakeryDbContext>().UseInMemoryDatabase(databaseName: "BakeryDB").Options;
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
            var mockOptions = new DbContextOptionsBuilder<BakeryDbContext>().UseInMemoryDatabase(databaseName: "BakeryDB").Options;
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

    }
}