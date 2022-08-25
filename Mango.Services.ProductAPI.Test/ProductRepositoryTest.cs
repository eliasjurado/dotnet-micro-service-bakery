using Mango.Services.ProductAPI.Test.Fixtures;
using Xunit;

namespace Mango.Services.ProductAPI.Test
{
    public class ProductRepositoryTest : IClassFixture<ProductRepositoryFixture>, IDisposable
    {
        public readonly ProductRepositoryFixture _fixture;

        public ProductRepositoryTest(ProductRepositoryFixture fixture)
        {
            _fixture = fixture;
        }

        //[Theory]
        //[ProductUpsertData]
        //public async void CreateUpdateProduct_IsOrNotCreated(ProductDto data, int resultId, bool expected)
        //{
        //    var mockContext = new ApplicationDbContext(_fixture.mockOptions);
        //    var mockRepository = new ProductRepository(mockContext, _fixture.mapper);

        //    var response = await mockRepository.CreateUpdateProduct(data);
        //    var result = response.ProductId == resultId;

        //    Assert.Equal(expected, result);
        //    mockContext.Dispose();
        //}

        //[Theory]
        //[ProductDeleteData]
        //public async void DeleteProduct_IsOrNotDeleted(Product data, int resultId, bool expected)
        //{
        //    var mockContext = new ApplicationDbContext(_fixture.mockOptions);
        //    mockContext.Products.Add(data);
        //    mockContext.SaveChanges();
        //    var mockRepository = new ProductRepository(mockContext, _fixture.mapper);

        //    var response = await mockRepository.DeleteProduct(resultId);

        //    Assert.Equal(expected, response);
        //    //mockContext.Products.RemoveRange();
        //    //mockContext.SaveChanges();
        //}

        public void Dispose()
        {
            _fixture.Dispose();
        }

        //[Theory]
        //[ProductGetData]
        //public async void GetProductById_ReturnProduct(Product data, int value, bool expected)
        //{
        //    var mockContext = new ApplicationDbContext(_fixture.mockOptions);
        //    mockContext.Products.Add(data);
        //    mockContext.SaveChanges();
        //    var mockRepository = new ProductRepository(mockContext, _fixture.mapper);

        //    var response = await mockRepository.GetProductById(value);
        //    var assertion = response.ProductId == value;

        //    Assert.Equal(expected, assertion);
        //    //mockContext.Products.RemoveRange();
        //    //mockContext.SaveChanges();
        //}

        //[Theory]
        //[ProductGetAllData]
        //public async void GetProducts_ReturnProductList(Product data, bool expected)
        //{
        //    var mockContext = new ApplicationDbContext(_fixture.mockOptions);
        //    mockContext.Products.Add(data);
        //    mockContext.SaveChanges();
        //    var mockRepository = new ProductRepository(mockContext, _fixture.mapper);

        //    var response = await mockRepository.GetProducts();
        //    var assertion = response.Count() > 0;

        //    Assert.Equal(expected, assertion);
        //    //mockContext.Products.RemoveRange();
        //    //mockContext.SaveChanges();
        //}
    }
}