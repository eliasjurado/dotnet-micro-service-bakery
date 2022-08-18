using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Application.Interfaces
{
    public interface IBakeryInventoryService
    {
        Task<BakeryResponse> RegisterBreadProductionAsync(int quantity, DateTime expirationDate, CancellationToken cancellationToken);
    }
}
