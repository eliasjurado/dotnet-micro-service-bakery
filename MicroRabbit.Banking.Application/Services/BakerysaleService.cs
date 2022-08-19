using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Application.Services
{
    public class BakerySaleService : IBakerySaleService
    {

        private readonly IBakeryRepository _bakeryRepository;

        public BakerySaleService(IBakeryRepository bakeryRepository)
        {
            _bakeryRepository = bakeryRepository ?? throw new ArgumentNullException(nameof(bakeryRepository));
        }

        public async Task<BakeryResponse> RegisterSaleAsync(float quantity, float price, CancellationToken cancellationToken)
        { 
            try
            {
                await _bakeryRepository.RegisterSaleAsync(quantity, price, cancellationToken);
                return new BakeryResponse { Message = "Process was sucessful" };
            }
            catch (Exception ex)
            {
                throw new Exception("Error registering bread production", ex);
            }
        }

    }
}