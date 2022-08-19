using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Application.Services
{
    public class TransferProductionService : ITransferProductionService
    {
        private readonly ITransferProductionRepository _transferProductionRepository;
        private readonly IEventBus _bus;

        public TransferProductionService(ITransferProductionRepository transferProductionRepository, IEventBus bus)
        {
            _transferProductionRepository = transferProductionRepository;
            _bus = bus;
        }
        public IEnumerable<TransferProductionLog> GetTransferProductionLogs()
        {
            return _transferProductionRepository.GetTransferProductionLogs();
        }

    }
}
