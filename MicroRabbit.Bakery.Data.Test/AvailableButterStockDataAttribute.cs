using MicroRabbit.Banking.Domain.Models;
using System.Reflection;
using Xunit.Sdk;

namespace Calculations.Test
{
    public class AvailableButterStockDataAttribute : DataAttribute
    {

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] {
                new Product { Id = 3, Name = "Butter", Cost = 100.0m, Creation_Date = DateTime.Parse("2022-08-18"), Stock = 100 } ,
                50f,
                true
            };
            yield return new object[] {
                new Product { Id = 3, Name = "Butter", Cost = 100.0m, Creation_Date = DateTime.Parse("2022-08-18"), Stock = 100 } ,
                100f,
                false
            };
            yield return new object[] {
                new Product { Id = 3, Name = "Butter", Cost = 100.0m, Creation_Date = DateTime.Parse("2022-08-18"), Stock = 100 } ,
                200f,
                false
            };
        }

    }
}
