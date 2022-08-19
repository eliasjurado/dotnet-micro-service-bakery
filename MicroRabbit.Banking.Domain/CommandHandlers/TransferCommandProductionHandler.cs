using MediatR;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Domain.CommandHandlers
{
    public class TransferCommandProductionHandler : IRequestHandler<CreateTransferProductionCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransferCommandProductionHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(CreateTransferProductionCommand request, CancellationToken cancellationToken)
        {
            //Publish event on RabbitMQ
            _bus.Publish(new TransferCreatedProductionEvent(request.ProductionAmount, request.ExpirationDate, request.IdProduct));

            return Task.FromResult(true);
        }
    }
}
