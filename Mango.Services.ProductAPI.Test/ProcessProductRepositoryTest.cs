using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dtos;
using Mango.Services.ProductAPI.Repository;
using Mango.Services.ProductAPI.Test.DataAttributes;
using Mango.Services.ProductAPI.Test.Fixtures;
using Xunit;

namespace ProductAPI.Test
{
    public class ProcessProductRepositoryTest : IClassFixture<ProductRepositoryFixture>
    {
        public readonly ProductRepositoryFixture _fixture;

        public ProcessProductRepositoryTest(ProductRepositoryFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ProcessProductStockData]
        public async void GetProductAvailableAsync_ReturnsQuantity(Product data, int arg, int result, bool expected)
        {
            var mockContext = new ApplicationDbContext(_fixture.mockOptions);
            mockContext.Products.Add(data);
            mockContext.SaveChanges();
            var mockRepository = new ProductRepository(mockContext, _fixture.mapper);

            var response = await mockRepository.GetProductAvailableAsync(arg);
            var assertion = response == result;

            Assert.Equal(expected, assertion);
            //mockContext.Products.RemoveRange();
            //mockContext.SaveChanges();
        }

        [Theory]
        [ProcessProductRegisterData]
        public async void RegisterBreadProductionAsync_IsOrNotCreated(ProcessProductDto data, bool expected)
        {
            var mockRepository = new ProductRepository(_fixture.dbContext, _fixture.mapper);

            var response = await mockRepository.RegisterBreadProductionAsync(data);
            var result = response.Stock == data.Stock;

            Assert.Equal(expected, result);

        }

        //[Theory]
        //[ProcessProductUpdateData]
        //public async void UpdateProductStockAsync_IsWellUpdated(Product data, double quantity, int IdProduct, double testBalance, bool expected)
        //{
        //    var mockContext = new ApplicationDbContext(_fixture.mockOptions);
        //    mockContext.Products.Add(data);
        //    mockContext.SaveChanges();
        //    var mockRepository = new ProductRepository(mockContext, _fixture.mapper);

        //    var response = await mockRepository.UpdateProductStockAsync(quantity, IdProduct);
        //    var result = response.Stock == testBalance;
        //    //mockContext.Products.RemoveRange();
        //    //mockContext.SaveChanges();

        //    Assert.Equal(expected, result);
        //}
    }
}
