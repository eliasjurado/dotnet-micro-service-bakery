using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Application.Interfaces
{
    public interface ITransferProductionService
    {
        IEnumerable<TransferProductionLog> GetTransferProductionLogs();
        void TransferStock(TransferProductionLog productionTransfer);
    }
}
