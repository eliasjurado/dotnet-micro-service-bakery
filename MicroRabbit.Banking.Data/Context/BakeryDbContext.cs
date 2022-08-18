using FluentAssertions.Common;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Banking.Data.Context
{
    public class BakeryDbContext : DbContext
    {
        public BakeryDbContext(DbContextOptions<BakeryDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.Current.ToString());
            }
        }
        public DbSet<Product> Products { set; get; }
        public DbSet<Processed_Product> ProcessedProduct { set; get; }
    }
}
