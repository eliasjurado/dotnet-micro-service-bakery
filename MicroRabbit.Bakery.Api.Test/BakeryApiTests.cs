using MicroRabbit.Banking.Api.Controllers;
using MicroRabbit.Banking.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Text;
using Xunit;

namespace PersonalPhotos.Test
{
    public class BakeryApiTests
    {
        [Fact]
        public async Task RegisterBreadProduction_100BreadsAndExpiresTheDayAfterTomorrow()
        {
            var session = Mock.Of<ISession>();
            session.Set("User", Encoding.UTF8.GetBytes("admin@bakery.com"));
            var context = Mock.Of<HttpContext>(x => x.Session == session);
            var accessor = Mock.Of<IHttpContextAccessor>(x => x.HttpContext == context);


            var bakeryInventoryService = Mock.Of<IBakeryInventoryService>();
            var controller = new BakeryInventoryController(bakeryInventoryService);

            float quantity = 100f;
            DateTime expirationDate = DateTime.Parse("2022-08-20");
            var cancellationToken = new CancellationTokenSource(1000);

            var result = await controller.RegisterBreadProduction(quantity, expirationDate, cancellationToken.Token) as RedirectToActionResult;

            Assert.Equal("Display", result.ActionName, ignoreCase: true);
        }

    }
}
