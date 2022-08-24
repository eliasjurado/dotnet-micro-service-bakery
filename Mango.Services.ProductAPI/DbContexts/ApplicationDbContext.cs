using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProcessProduct> ProcessProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Bread",
                Price = 1,
                Description = "Bread is a food consisting of flour or meal that is moistened, kneaded into dough, and often fermented using yeast, and it has been a major sustenance since prehistoric times.",
                ImageUrl = "https://dojoblob.blob.core.windows.net/store/bread.jpg",
                CategoryName = "Food"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Butter",
                Price = 13.99,
                Description = "Butter is a dairy product made from the fat and protein components of churned cream. It is a semi-solid emulsion at room temperature, consisting of approximately 80% butterfat. It is used at room temperature as a spread, melted as a condiment, and used as a fat in baking, sauce-making, pan frying, and other cooking procedures.",
                ImageUrl = "https://dojoblob.blob.core.windows.net/store/butter.jpg",
                CategoryName = "Food"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Flour",
                Price = 10.99,
                Description = "Flour is a powder made by grinding raw grains, roots, beans, nuts, or seeds",
                ImageUrl = "https://dojoblob.blob.core.windows.net/store/flour.jpg",
                CategoryName = "Food"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Coffee",
                Price = 15,
                Description = "Coffee is a brewed drink prepared from roasted coffee beans, the seeds of berries from certain flowering plants in the Coffea genus",
                ImageUrl = "https://dojoblob.blob.core.windows.net/store/coffee.jpg",
                CategoryName = "Drink"
            });
            
        }
    }
}
