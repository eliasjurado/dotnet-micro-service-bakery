namespace MicroRabbit.Banking.Application.Models
{
    public class ProductionTransfer
    {
        public int ProductionAmount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int IdProduct { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
