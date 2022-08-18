using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Application.Interfaces
{
    public interface IBakeryInventoryService
    {
        Task<BakeryResponse> RegisterBreadProductionAsync(float quantity, DateTime expirationDate, CancellationToken cancellationToken);

        Task<IEnumerable<BakeryProcessedProduct>> GetProcessedProductionAsyn(DateTime? expirationDate, CancellationToken cancellationToken);

        Task<IEnumerable<Product>> GetInventoryAsyn(int? idProduct, CancellationToken cancellationToken);
    }
}