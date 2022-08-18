using MicroRabbit.Banking.Api.Controllers;
using MicroRabbit.Banking.Application.Interfaces;
using Moq;

namespace MicroRabbit.Bakery.Api.Test.Fixtures
{
    public class BakeryApiFixture
    {
        public BakeryInventoryController bakeryInventorySingleton => new BakeryInventoryController(Mock.Of<IBakeryInventoryService>());
        public void Dispose()
        {
            //Clean
        }
    }
}
