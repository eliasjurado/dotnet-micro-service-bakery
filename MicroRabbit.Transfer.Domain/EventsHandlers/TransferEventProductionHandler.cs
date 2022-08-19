using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Domain.EventsHandlers
{
    public class TransferProductionEventHandler : IEventHandler<TransferCreatedProductionEvent>
    {
        private readonly ITransferProductionRepository _transProductionferRepository;
        public TransferProductionEventHandler(ITransferProductionRepository transferProductionRepository)
        {
            _transProductionferRepository = transferProductionRepository;
        }
        public Task Handle(TransferCreatedProductionEvent @event)
        {
            _transProductionferRepository.Add(new TransferProductionLog()
            {
                ProductionAmount = @event.ProductionAmount,
                ExpirationDate = @event.ExpirationDate,
                IdProduct = @event.IdProduct,
                ProductionDate = @event.ProductionDate,
            });
            return Task.CompletedTask;
        }
    }
}
