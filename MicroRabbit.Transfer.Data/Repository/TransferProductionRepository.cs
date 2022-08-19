using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TransferProductionRepository : ITransferProductionRepository
    {
        private TransferDbContext _ctx;

        public TransferProductionRepository(TransferDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(TransferProductionLog transferProductionLog)
        {
            _ctx.TransferProductionLogs.Add(transferProductionLog);
            _ctx.SaveChanges();
        }
        public IEnumerable<TransferProductionLog> GetTransferProductionLogs()
        {
            return _ctx.TransferProductionLogs;
        }
    }
}
