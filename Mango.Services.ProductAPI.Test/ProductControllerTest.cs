﻿using Mango.Services.ProductAPI.Controllers;
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

        //      public async Task<object> Post([FromBody] ProductDto productDto)
        //      public async Task<object> Put([FromBody] ProductDto productDto)
        //      public async Task<object> Delete(int id)
    }
}
