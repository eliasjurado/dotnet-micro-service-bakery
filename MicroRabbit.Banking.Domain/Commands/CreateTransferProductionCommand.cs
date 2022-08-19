namespace MicroRabbit.Banking.Domain.Commands
{
    public class CreateTransferProductionCommand : TransferProductionCommand
    {
        public CreateTransferProductionCommand(int productionAmount, DateTime expirationDate, int idProduct, DateTime productionDate)
        {
            ProductionAmount = productionAmount;
            ExpirationDate = expirationDate;
            IdProduct = idProduct;
            ProductionDate = productionDate;
        }
    }
}
