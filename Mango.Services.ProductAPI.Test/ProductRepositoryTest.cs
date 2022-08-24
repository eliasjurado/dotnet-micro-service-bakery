using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Repository;
using Mango.Services.ProductAPI.Test.DataAttributes;
using Mango.Services.ProductAPI.Test.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace Mango.Services.ProductAPI.Test
{
    public class ProductRepositoryTest : IClassFixture<ProductRepositoryFixture>
    {
        public readonly ITestOutputHelper _testOutputHelper;
        public readonly ProductRepositoryFixture _fixture;
        public readonly IMapper _mapper;

        public ProductRepositoryTest(IMapper mapper, ITestOutputHelper testOutputHelper, ProductRepositoryFixture fixture)
        {
            _testOutputHelper = testOutputHelper;
            _fixture = fixture;
            _mapper = mapper;
        }

        [Theory]
        [AvailableButterStockData]
        public void AvailableButterStock_IsEnoughButter(Product data, float value, bool expected)
        {
            _testOutputHelper.WriteLine($"AvailableButterStock_IsEnoughButter - {DateTime.Now}");
            var mockContext = new ApplicationDbContext(_fixture.mockOptions);
            mockContext.Products.Add(data);
            mockContext.SaveChanges();
            var mockRepository = new ProductRepository(mockContext, _mapper);

            var result = mockRepository.AvailableButterStock(value);
            mockContext.Products.RemoveRange(mockContext.Products);
            mockContext.SaveChanges();

            Assert.Equal(expected, result);
        }




        [Theory]
        [AvailableFlourStockData]
        public void AvailableFlourStock_IsEnoughFlour(Product data, float value, bool expected)
        {
            _testOutputHelper.WriteLine($"AvailableFlourStock_IsEnoughFlour - {DateTime.Now}");
            var mockContext = new ApplicationDbContext(_fixture.mockOptions);
            mockContext.Products.Add(data);
            mockContext.SaveChanges();
            var mockRepository = new ProductRepository(mockContext, _mapper);

            var result = mockRepository.AvailableFlourStock(value);
            mockContext.Products.RemoveRange(mockContext.Products);
            mockContext.SaveChanges();

            Assert.Equal(expected, result);
        }

        [Theory]
        [ConsumingInventoryDataAttribute]
        public async Task ConsumingInventoryAsync_RemovesStockFromFlourAndButter(Product butter, Product flour, float projectedFlour, float projectedButter, int expectedFlourBalance, int expectedButterBalance)
        {
            _testOutputHelper.WriteLine($"ConsumingInventoryAsync_RemovesStockFromFlourAndButter - {DateTime.Now}");
            var mockContext = new ApplicationDbContext(_fixture.mockOptions);

            mockContext.Products.AddRange(butter);
            mockContext.Products.Add(flour);
            mockContext.SaveChanges();

            var mockRepository = new ProductRepository(mockContext, _mapper);

            await mockRepository.ConsumingInventoryAsync(projectedFlour, projectedButter, _fixture.cancellationTokenSource.Token);
            var resultButterBalance = mockContext.Products.Find(butter.ProductId).Stock;
            var resultFlourBalance = mockContext.Products.Find(flour.ProductId).Stock;
            mockContext.Products.RemoveRange(mockContext.Products);
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