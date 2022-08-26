using Mango.Services.ProductAPI.Controllers;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Models.Dtos;
using Mango.Services.ProductAPI.Repository;
using Mango.Services.ProductAPI.Test.DataAttributes;
using Mango.Services.ProductAPI.Test.Fixtures;
using Xunit;

namespace Mango.Services.ProductAPI.Test
{
    public class ProductControllerTest : IClassFixture<ProductRepositoryFixture>
    {
        public readonly ProductRepositoryFixture _fixture;

        public ProductControllerTest(ProductRepositoryFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public void ProductAPIController_ReturnsInstance()
        {
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                var repository = new ProductRepository(context, _fixture.mapper);
                var result = new ProductAPIController(repository);
                Assert.IsType<ProductAPIController>(result);
            }
        }
        [Theory]
        [ProductGetAllData]
        public async void Get_ReturnsProductList(List<Product> data, bool expected)
        {
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                context.Products.AddRange(data);
                context.SaveChanges();
                var repository = new ProductRepository(context, _fixture.mapper);
                var controller = new ProductAPIController(repository);
                var response = (ResponseDto)await controller.Get();

                var assertion = typeof(ProductDto) == response.Result.GetType() || typeof(List<ProductDto>) == response.Result.GetType();

                Assert.Equal(expected, assertion);
            }
        }

        [Theory]
        [ProductGetData]
        public async void GetById_ReturnsProduct(Product data, int arg, bool expected)
        {
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                context.Products.AddRange(data);
                context.SaveChanges();
                var repository = new ProductRepository(context, _fixture.mapper);
                var controller = new ProductAPIController(repository);
                var response = (ResponseDto)await controller.Get(arg);

                var assertion = typeof(ProductDto) == response.Result.GetType();

                Assert.Equal(expected, assertion);
            }
        }

        [Theory]
        [ProductInsertData]
        public async void Post_ReturnsInsertedProduct(ProductDto expected)
        {
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                var repository = new ProductRepository(context, _fixture.mapper);
                var controller = new ProductAPIController(repository);

                var response = await controller.Post(expected);
                var updated = (ProductDto)((ResponseDto)response).Result;

                Assert.Equal(expected.Name, updated.Name);
                Assert.Equal(expected.Price, updated.Price);
                Assert.Equal(expected.Stock, updated.Stock);
                Assert.Equal(expected.Description, updated.Description);
                Assert.Equal(expected.CategoryName, updated.CategoryName);
                Assert.Equal(expected.ImageUrl, updated.ImageUrl);
            }
        }

        [Theory]
        [ProductDeleteData]
        public async void Delete_ReturnsInsertedProduct(Product data, int arg, bool expected)
        {
            using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
            {
                context.Products.Add(data);
                context.SaveChanges();
                var repository = new ProductRepository(context, _fixture.mapper);
                var controller = new ProductAPIController(repository);

                var response = await controller.Delete(arg);
                var deleted = (ResponseDto)response;
                var assertion = deleted.IsSuccess == expected;

                Assert.Equal(expected, assertion);
            }
        }

        //[Theory]
        //[ProductUpdateData]
        //public async void Put_ReturnsUpdatedProduct(Product data, ProductDto expected)
        //{
        //    using (var context = new ApplicationDbContext(_fixture.CreateNewContextOptions()))
        //    {
        //        context.Products.AddRange(data);
        //        context.SaveChanges();
        //        var repository = new ProductRepository(context, _fixture.mapper);
        //        var controller = new ProductAPIController(repository);

        //        var response = await controller.Put(expected);
        //        var updated = (ProductDto)((ResponseDto)response).Result;
        //        //Equal
        //        Assert.NotEqual(expected.ProductId, updated.ProductId);
        //        Assert.NotEqual(expected.Name, updated.Name);
        //        Assert.NotEqual(expected.Price, updated.Price);
        //        Assert.NotEqual(expected.Stock, updated.Stock);
        //        Assert.NotEqual(expected.Description, updated.Description);
        //        Assert.NotEqual(expected.CategoryName, updated.CategoryName);
        //        Assert.NotEqual(expected.ImageUrl, updated.ImageUrl);
        //    }
        //}
    }
}
