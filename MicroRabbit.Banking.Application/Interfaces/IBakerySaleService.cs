using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Application.Interfaces
{
    public interface IBakerySaleService
    {
        Task<BakeryResponse> RegisterSaleAsync(float quantity, float price, CancellationToken cancellationToken);

    }
}