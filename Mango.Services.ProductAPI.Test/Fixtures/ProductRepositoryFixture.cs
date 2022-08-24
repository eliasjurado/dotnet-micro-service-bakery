using Mango.Services.ProductAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Mango.Services.ProductAPI.Test.Fixtures
{
    public class ProductRepositoryFixture : IDisposable
    {
        public MemoryStream memoryStream => new MemoryStream();
        public DbContextOptions<ApplicationDbContext> mockOptions => new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "dbProduct")
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;
        public CancellationTokenSource cancellationTokenSource => new CancellationTokenSource(1000);
        public void Dispose()
        {
            memoryStream.Close();
        }
    }
}
