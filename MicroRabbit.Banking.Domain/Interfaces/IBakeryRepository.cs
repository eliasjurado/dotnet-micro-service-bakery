namespace MicroRabbit.Banking.Domain.Interfaces
{
    public interface IBakeryRepository
    {
        bool AvailableButterStock(float quantity);
        bool AvailableFlourStock(float quantity);
        Task ConsumingInventoryAsync(float projectedFlour, float projectedButter, CancellationToken cancellationToken);
        Task RegisterProductionAsync(float amount, DateTime expirationDate, CancellationToken cancellationToken);
    }
}
