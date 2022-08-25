using Mango.Services.ProductAPI.Models;
using System.Reflection;
using Xunit.Sdk;

namespace Mango.Services.ProductAPI.Test.DataAttributes
{
    public class ProductGetAllDataAttribute : DataAttribute
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
                true
            };
            //yield return new object[] {
            //    new Product { ProductId = 2,
            //    Name = "Bread",
            //    Price = 1,
            //    Stock = 10,
            //    Description = "Bread is a food consisting of flour or meal that is moistened, kneaded into dough, and often fermented using yeast, and it has been a major sustenance since prehistoric times.",
            //    ImageUrl = "https://dojoblob.blob.core.windows.net/store/bread.jpg",
            //    CategoryName = "Food" } ,
            //    true
            //};
            //yield return new object[] {
            //    new Product { ProductId = 3,
            //    Name = "Bread",
            //    Price = 1,
            //    Stock = 10,
            //    Description = "Bread is a food consisting of flour or meal that is moistened, kneaded into dough, and often fermented using yeast, and it has been a major sustenance since prehistoric times.",
            //    ImageUrl = "https://dojoblob.blob.core.windows.net/store/bread.jpg",
            //    CategoryName = "Food" } ,
            //    true
            //};

        }

    }
}
