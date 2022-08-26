using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dtos;
using System.Reflection;
using Xunit.Sdk;

namespace Mango.Services.ProductAPI.Test.DataAttributes
{
    public class ProductUpdateDataAttribute : DataAttribute
    {

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {

            yield return new object[] {
                new Product { ProductId = 1,
                Name = "Bread",
                Price = 1,
                Stock = 10,
                Description = "Bread is a food consisting of flour or meal that is moistened, kneaded into dough, and often fermented using yeast, and it has been a major sustenance since prehistoric times.",
                ImageUrl = "https://dojoblob.blob.core.windows.net/store/bread.jpg",
                CategoryName = "Food" } ,
                new ProductDto { ProductId = 1,
                Name = "Name Updated",
                Price = 2,
                Stock = 100,
                Description = "Description Updated",
                ImageUrl = "ImageUrl Updated",
                CategoryName = "CategoryName Updated" } ,
            };
            yield return new object[] {
                new Product { ProductId = 1,
                Name = "Bread",
                Price = 1,
                Stock = 10,
                Description = "Bread is a food consisting of flour or meal that is moistened, kneaded into dough, and often fermented using yeast, and it has been a major sustenance since prehistoric times.",
                ImageUrl = "https://dojoblob.blob.core.windows.net/store/bread.jpg",
                CategoryName = "Food" } ,
                new ProductDto { ProductId = 1,
                Name = "Name Updated",
                Price = 2,
                Stock = 100,
                Description = "Description Updated",
                ImageUrl = "ImageUrl Updated",
                CategoryName = "CategoryName Updated" } ,
            };
            yield return new object[] {
                new Product { ProductId = 1,
                Name = "Bread",
                Price = 1,
                Stock = 10,
                Description = "Bread is a food consisting of flour or meal that is moistened, kneaded into dough, and often fermented using yeast, and it has been a major sustenance since prehistoric times.",
                ImageUrl = "https://dojoblob.blob.core.windows.net/store/bread.jpg",
                CategoryName = "Food" } ,
                new ProductDto { ProductId = 1,
                Name = "Name Updated",
                Price = 2,
                Stock = 100,
                Description = "Description Updated",
                ImageUrl = "ImageUrl Updated",
                CategoryName = "CategoryName Updated" } ,
            };

        }

    }
}
