using Mango.Services.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.OrderAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override  void OnModelCreating(ModelBuilder model)
        {
            //model.Entity<SellHeader>().Property(t => t.IdSellHeader).ValueGeneratedOnAdd();
            //model.Entity<SellDetails>().Property(t => t.Id).ValueGeneratedOnAdd();
            //model.Entity<SellHeader>().Property(t => t.IdSellHeader).ValueGeneratedOnAdd();
        }
        

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<SellHeader> SellHeaders { get; set; }
        public DbSet<SellDetails> SellDetails { get; set; }
    }
}