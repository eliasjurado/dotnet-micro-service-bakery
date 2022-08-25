using Mango.Services.ProductAPI.Models.Dtos;
using System.Reflection;
using Xunit.Sdk;

namespace Mango.Services.ProductAPI.Test.DataAttributes
{
    public class ProcessProductRegisterDataAttribute : DataAttribute
    {

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] {
                new ProcessProductDto {
                    Id=0,
                    ProductId = 1,
                    Stock = 10,
                    ProductionDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddDays(2),
                } ,
                true
            };
            //yield return new object[] {
            //    new ProcessProductDto {
            //        Id=0,
            //        ProductId = 1,
            //        Stock = 100,
            //        ProductionDate = DateTime.Now,
            //        ExpirationDate = DateTime.Now.AddDays(2),
            //    } ,
            //    true
            //};
            //yield return new object[] {
            //    new ProcessProductDto {
            //        Id=0,
            //        ProductId = 1,
            //        Stock = 150,
            //        ProductionDate = DateTime.Now,
            //        ExpirationDate = DateTime.Now.AddDays(2),
            //    } ,
            //    true
            //};
        }
    }
}
