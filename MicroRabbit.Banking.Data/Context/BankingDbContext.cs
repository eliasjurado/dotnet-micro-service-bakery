using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Banking.Data.Context
{

    public class BankingDbContext : DbContext
    {
        public BankingDbContext()
        {
        }
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=PE-IT001549;Database=BankingDB;Trusted_Connection=True;");
            }
        }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(b => b.AccountType)
                .HasMaxLength(20);
        }
    }
}
