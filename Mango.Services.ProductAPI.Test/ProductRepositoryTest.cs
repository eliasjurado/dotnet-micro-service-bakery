using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dtos;
using Mango.Services.ProductAPI.Repository;
using Mango.Services.ProductAPI.Test.DataAttributes;
using Mango.Services.ProductAPI.Test.Fixtures;
using Xunit;

namespace Mango.Services.ProductAPI.Test
{
    public class ProductRepositoryTest : IClassFixture<ProductRepositoryFixture>
    {
        public readonly ProductRepositoryFixture _fixture;

        public ProductRepositoryTest(ProductRepositoryFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public void ProductRepository_ReturnsInstance()
        {
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                var result = new ProductRepository(context, _fixture.mapper);
                Assert.IsType<ProductRepository>(result);
            }
        }

        [Theory]
        [ProductUpsertData]
        public async void CreateUpdateProduct_IsOrNotCreated(ProductDto data, int resultId, bool expected)
        {
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                var mockRepository = new ProductRepository(context, _fixture.mapper);
                var response = await mockRepository.CreateUpdateProduct(data);
                var result = response.ProductId == resultId;
                Assert.Equal(expected, result);
            }
        }

        [Theory]
        [ProductDeleteData]
        public async void DeleteProduct_IsOrNotDeleted(Product data, int resultId, bool expected)
        {
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                context.Products.Add(data);
                context.SaveChanges();
                var repository = new ProductRepository(context, _fixture.mapper);
                var response = await repository.DeleteProduct(resultId);
                Assert.Equal(expected, response);
            }
        }

        [Theory]
        [ProductGetData]
        public async void GetProductById_ReturnProduct(Product data, int value, bool expected)
        {
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                context.Products.Add(data);
                context.SaveChanges();
                var mockRepository = new ProductRepository(context, _fixture.mapper);
                var response = await mockRepository.GetProductById(value);
                var assertion = response.ProductId == value;
                Assert.Equal(expected, assertion);
            }
        }

        [Theory]
        [ProductGetAllData]
        public async void GetProducts_ReturnProductList(List<Product> data, bool expected)
        {
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                context.Products.AddRange(data);
                context.SaveChanges();
                var repository = new ProductRepository(context, _fixture.mapper);
                var response = await repository.GetProducts();
                var assertion = response.Count() > 0;

                Assert.Equal(expected, assertion);
            }
        }
    }
}