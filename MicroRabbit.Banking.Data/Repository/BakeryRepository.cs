using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Data.Repository
{
    public class BakeryRepository : IBakeryRepository
    {
        private BakeryDbContext _ctx;
        private const int _idButter = 5;
        private const int _idFluor = 4;
        private const int _idBread = 1;

        public BakeryRepository(BakeryDbContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public bool AvailableButterStock(int quantity)
        {
            var product = _ctx.Products.Find(_idButter);
            return product.Stock <= quantity;
        }

        public bool AvailableFlourStock(int quantity)
        {
            var product = _ctx.Products.Find(_idFluor);
            return product.Stock <= quantity;
        }

        public async Task ConsumingInventoryAsync(int projectedFlour, int projectedButter, CancellationToken cancellationToken)
        {
            try
            {
                var product = _ctx.Products.Find(_idFluor);
                product.Stock -= projectedFlour;
                await _ctx.SaveChangesAsync(cancellationToken);

                product = _ctx.Products.Find(_idButter);
                product.Stock -= projectedButter;
                await _ctx.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RegisterProductionAsync(int amount, DateTime expirationDate, CancellationToken cancellationToken)
        {
            try
            {
                var processedProduct = new Processed_Product
                {
                    Amount = amount,
                    Expiration_Date = expirationDate
                };
                await _ctx.ProcessedProduct.AddAsync(processedProduct, cancellationToken);

                var product = _ctx.Products.Find(_idBread);
                product.Stock += amount;
                await _ctx.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}