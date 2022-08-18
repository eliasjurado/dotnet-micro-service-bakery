namespace MicroRabbit.Banking.Domain.Interfaces
{
    public interface IBakeryRepository
    {
        bool AvailableButterStock(int quantity);
        bool AvailableFlourStock(int quantity);
        Task ConsumingInventoryAsync(int projectedFlour, int projectedButter, CancellationToken cancellationToken);
        Task RegisterProductionAsync(int amount, DateTime expirationDate, CancellationToken cancellationToken);
    }
}
