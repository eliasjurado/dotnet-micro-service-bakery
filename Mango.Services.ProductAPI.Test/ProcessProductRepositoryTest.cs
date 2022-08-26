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
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                context.Products.Add(data);
                context.SaveChanges();
                var repository = new ProductRepository(context, _fixture.mapper);
                var response = await repository.GetProductAvailableAsync(arg);
                var assertion = response == result;
                Assert.Equal(expected, assertion);
            }
        }

        [Theory]
        [ProcessProductRegisterData]
        public async void RegisterBreadProductionAsync_IsOrNotCreated(ProcessProductDto data, bool expected)
        {
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                var repository = new ProductRepository(context, _fixture.mapper);
                var response = await repository.RegisterBreadProductionAsync(data);
                var result = response.Stock == data.Stock;
                Assert.Equal(expected, result);
            }
        }

        [Theory]
        [ProcessProductUpdateData]
        public async void UpdateProductStockAsync_IsWellUpdated(Product data, double quantity, int IdProduct, double testBalance, bool expected)
        {
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                context.Products.Add(data);
                context.SaveChanges();
                var repository = new ProductRepository(context, _fixture.mapper);
                var response = await repository.UpdateProductStockAsync(quantity, IdProduct);
                var result = response.Stock == testBalance;
                Assert.Equal(expected, result);
            }
        }
    }
}
