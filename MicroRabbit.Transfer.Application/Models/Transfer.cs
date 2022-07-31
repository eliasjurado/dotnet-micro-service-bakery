namespace MicroRabbit.Banking.Application.Models
{
    public class Transfer
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
