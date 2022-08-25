using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Mango.Services.ProductAPI.Test.Fixtures
{
    public class ProductRepositoryFixture : IDisposable
    {
        public static string dbName = "dbProduct";

        public IMapper mapper = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductDto, Product>();
            config.CreateMap<Product, ProductDto>();
            config.CreateMap<ProcessProductDto, ProcessProduct>();
            config.CreateMap<ProcessProduct, ProcessProductDto>();
        }).CreateMapper();

        public DbContextOptions<ApplicationDbContext> mockOptions => new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        public ApplicationDbContext dbContext => new ApplicationDbContext(mockOptions);

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
