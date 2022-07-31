using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Data.Context
{
    
    public class BankingDbContext: DbContext
    {
        public BankingDbContext()
        {
        }
        public BankingDbContext(DbContextOptions options) :base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=PE-IT001549;Database=BankingDB;Trusted_Connection=True;");
            }
        }
        public DbSet<Account>Accounts { get; set; }
    }
}
