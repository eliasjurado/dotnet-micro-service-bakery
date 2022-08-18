using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Application.Services
{
    public class BakeryinventoryService : IBakeryInventoryService
    {
        private const int _breadsPerDay = 250;
        private const int _requiredFlour = 22;
        private const int _requiredButter = 15;
        private readonly IBakeryRepository _bakeryRepository;

        public BakeryinventoryService(IBakeryRepository bakeryRepository)
        {
            _bakeryRepository = bakeryRepository ?? throw new ArgumentNullException(nameof(bakeryRepository));
        }

        public async Task<BakeryResponse> RegisterBreadProductionAsync(int quantity, DateTime expirationDate, CancellationToken cancellationToken)
        {
            var projectedFlour = (quantity * _requiredFlour) / _breadsPerDay;
            var projectedButter = (quantity * _requiredButter) / _breadsPerDay;

            if (!_bakeryRepository.AvailableFlourStock(projectedFlour))
                throw new Exception("No available flour stock");

            if (!_bakeryRepository.AvailableButterStock(projectedButter))
                throw new Exception("No available butter stock");

            await _bakeryRepository.ConsumingInventoryAsync(projectedFlour, projectedButter, cancellationToken);
            await _bakeryRepository.RegisterProductionAsync(quantity, expirationDate, cancellationToken);

            return new BakeryResponse { Message = "Process was sucessful" };
        }
    }
}