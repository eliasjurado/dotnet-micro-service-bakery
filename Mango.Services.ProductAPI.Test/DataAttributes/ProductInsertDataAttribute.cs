using Mango.Services.ProductAPI.Models.Dtos;
using System.Reflection;
using Xunit.Sdk;

namespace Mango.Services.ProductAPI.Test.DataAttributes
{
    public class ProductInsertDataAttribute : DataAttribute
    {

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {

            yield return new object[] {
                new ProductDto { ProductId = 0,
                Name = "Bread",
                Price = 1,
                Stock = 10,
                Description = "Bread is a food consisting of flour or meal that is moistened, kneaded into dough, and often fermented using yeast, and it has been a major sustenance since prehistoric times.",
                ImageUrl = "https://dojoblob.blob.core.windows.net/store/bread.jpg",
                CategoryName = "Food" } ,
            };
            yield return new object[] {
                new ProductDto { ProductId = 0,
                Name = "Bread",
                Price = 1,
                Stock = 10,
                Description = "Bread is a food consisting of flour or meal that is moistened, kneaded into dough, and often fermented using yeast, and it has been a major sustenance since prehistoric times.",
                ImageUrl = "https://dojoblob.blob.core.windows.net/store/bread.jpg",
                CategoryName = "Food" } ,
            };
            yield return new object[] {
                new ProductDto { ProductId = 0,
                Name = "Bread",
                Price = 1,
                Stock = 10,
                Description = "Bread is a food consisting of flour or meal that is moistened, kneaded into dough, and often fermented using yeast, and it has been a major sustenance since prehistoric times.",
                ImageUrl = "https://dojoblob.blob.core.windows.net/store/bread.jpg",
                CategoryName = "Food" } ,
            };

        }

    }
}
