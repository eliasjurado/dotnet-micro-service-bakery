using MicroRabbit.Domain.Core.Commands;

namespace MicroRabbit.Banking.Domain.Commands
{
    public abstract class TransferProductionCommand : Command
    {
        public int ProductionAmount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int IdProduct { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
