using Mango.Services.ProductAPI.Models;
using System.Reflection;
using Xunit.Sdk;

namespace Mango.Services.ProductAPI.Test.DataAttributes
{
    public class RegisterProductionDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] {
                new Product { Id = 3, Name = "Butter", Cost = 100.0m, Creation_Date = DateTime.Parse("2022-08-18"), Stock = 1000 } ,
                new Product { Id = 2, Name = "Flour", Cost = 100.0m, Creation_Date = DateTime.Parse("2022-08-18"), Stock = 1000 } ,
                50f,
                50f,
                950,
                950
            };
            yield return new object[] {
                new Product { Id = 3, Name = "Butter", Cost = 100.0m, Creation_Date = DateTime.Parse("2022-08-18"), Stock = 950 } ,
                new Product { Id = 2, Name = "Flour", Cost = 100.0m, Creation_Date = DateTime.Parse("2022-08-18"), Stock = 950 } ,
                100f,
                100f,
                850,
                850
            };
            yield return new object[] {
                new Product { Id = 3, Name = "Butter", Cost = 100.0m, Creation_Date = DateTime.Parse("2022-08-18"), Stock = 850 } ,
                new Product { Id = 2, Name = "Flour", Cost = 100.0m, Creation_Date = DateTime.Parse("2022-08-18"), Stock = 850 } ,
                200f,
                200f,
                650,
                650
            };
        }
    }
}
