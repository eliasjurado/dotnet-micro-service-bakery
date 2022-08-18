using System.Reflection;
using Xunit.Sdk;

namespace Calculations.Test
{
    public class RegisterBreadProductionDataAttribute : DataAttribute
    {

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 100, DateTime.Parse("2022-08-20") };
            yield return new object[] { 200, DateTime.Parse("2022-08-20") };
        }

    }
}
