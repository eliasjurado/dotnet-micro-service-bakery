using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Domain.Interfaces
{
    public interface ITransferProductionRepository
    {
        IEnumerable<TransferProductionLog> GetTransferProductionLogs();
        public void Add(TransferProductionLog transferProductionLog);
    }
}
