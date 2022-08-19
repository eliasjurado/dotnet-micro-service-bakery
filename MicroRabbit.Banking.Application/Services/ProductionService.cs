using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Application.Services
{
    public class ProductionService : IProductionService
    {
        private readonly IEventBus _bus;

        public ProductionService(IEventBus bus)
        {
            _bus = bus;
        }

        public void Transfer(ProductionTransfer productionTransfer)
        {
            var createTransferCommand = new CreateTransferProductionCommand(
                productionTransfer.ProductionAmount,
                productionTransfer.ExpirationDate,
                productionTransfer.IdProduct
                );
            _bus.SendCommand(createTransferCommand);
        }
    }
}
