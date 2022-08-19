using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.Transfer.Domain.Events
{
    public class TransferCreatedProductionEvent : Event
    {
        public int ProductionAmount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int IdProduct { get; set; }
        public DateTime ProductionDate { get; set; }

        public TransferCreatedProductionEvent(int productionAmount, DateTime expirationDate, int idProduct, DateTime productionDate)
        {
            ProductionAmount = productionAmount;
            ExpirationDate = expirationDate;
            IdProduct = idProduct;
            ProductionDate = productionDate;
        }
    }
}
