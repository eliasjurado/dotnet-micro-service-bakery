using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Domain.Interfaces
{
    public interface IBakeryRepository
    {
        bool AvailableButterStock(float quantity);

        bool AvailableFlourStock(float quantity);

        Task ConsumingInventoryAsync(float projectedFlour, float projectedButter, CancellationToken cancellationToken);

        Task RegisterProductionAsync(float amount, DateTime expirationDate, CancellationToken cancellationToken);

        Task RegisterSaleAsync(float quantity, float price, CancellationToken cancellationToken);

        Task<IEnumerable<BakeryProcessedProduct>> GetProcessedProductionAsyn(CancellationToken cancellationToken);

        Task<IEnumerable<Product>> GetInventoryAsyn(CancellationToken cancellationToken);
    }
}