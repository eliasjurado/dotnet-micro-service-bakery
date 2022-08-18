using Calculations.Test;
using MicroRabbit.Bakery.Api.Test.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Abstractions;

namespace PersonalPhotos.Test
{
    public class BakeryApiTests : IClassFixture<BakeryApiFixture>
    {
        public readonly ITestOutputHelper _testOutputHelper;
        public readonly BakeryApiFixture _bakeryApiFixture;

        [Theory]
        [RegisterBreadProductionData]
        public async Task RegisterBreadProduction_100BreadsAndExpiresTheDayAfterTomorrow(float quantity, DateTime expirationDate)
        {
            var controller = _bakeryApiFixture.bakeryInventorySingleton;
            var cancellationToken = new CancellationTokenSource(1000);
            var result = await controller.RegisterBreadProduction(quantity, expirationDate, cancellationToken.Token) as RedirectToActionResult;

            Assert.Equal("Display", result.ActionName, ignoreCase: true);
        }

    }
}
