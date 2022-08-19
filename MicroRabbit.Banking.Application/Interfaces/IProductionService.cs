using MicroRabbit.Banking.Application.Models;

namespace MicroRabbit.Banking.Application.Interfaces
{
    public interface IProductionService
    {
        void Transfer(ProductionTransfer productionTransfer);
    }
}
