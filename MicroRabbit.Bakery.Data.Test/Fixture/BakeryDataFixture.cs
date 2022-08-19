using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace MicroRabbit.Banking.Data.Test.Fixture
{
    public class BakeryDataFixture : IDisposable
    {
        public MemoryStream memoryStream => new MemoryStream();
        public IOptions<ProductSetting> mockSettings => Options.Create<ProductSetting>(new ProductSetting() { BreadId = 1, FlourId = 2, ButterId = 3 });
        public DbContextOptions<BakeryDbContext> mockOptions => new DbContextOptionsBuilder<BakeryDbContext>().UseInMemoryDatabase(databaseName: "BakeryDB").ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;
        public CancellationTokenSource cancellationTokenSource => new CancellationTokenSource(1000);
        public void Dispose()
        {
            memoryStream.Close();
        }
    }
}
