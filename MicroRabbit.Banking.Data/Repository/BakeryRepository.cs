using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MicroRabbit.Banking.Data.Repository
{
    public class BakeryRepository : IBakeryRepository
    {
        private BakeryDbContext _ctx;
        private int _idButter = 3;
        private int _idFluor = 2;
        private int _idBread = 1;

        private readonly IOptions<ProductSetting> _appSettings;

        public BakeryRepository(BakeryDbContext ctx, IOptions<ProductSetting> appSettings)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));

            _idBread = _appSettings.Value.BreadId;
            _idButter = _appSettings.Value.ButterId;
            _idFluor = _appSettings.Value.FlourId;
        }

        public bool AvailableButterStock(float quantity)
        {
            var product = _ctx.Product.Find(_idButter);
            return product.Stock > (int)Math.Ceiling(quantity);
        }

        public bool AvailableFlourStock(float quantity)
        {
            var product = _ctx.Product.Find(_idFluor);
            return product.Stock > (int)Math.Ceiling(quantity);
        }

        public async Task ConsumingInventoryAsync(float projectedFlour, float projectedButter, CancellationToken cancellationToken)
        {
            try
            {
                using var transaction = _ctx.Database.BeginTransaction();

                try
                {
                    var product = _ctx.Product.Find(_idFluor);
                    product.Stock -= (int)Math.Ceiling(projectedFlour);
                    await _ctx.SaveChangesAsync(cancellationToken);

                    product = _ctx.Product.Find(_idButter);
                    product.Stock -= (int)Math.Ceiling(projectedButter);
                    await _ctx.SaveChangesAsync(cancellationToken);

                    await transaction.CommitAsync(cancellationToken);
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RegisterProductionAsync(float amount, DateTime expirationDate, CancellationToken cancellationToken)
        {
            try
            {
                using var transaction = _ctx.Database.BeginTransaction();
                try
                {
                    var processedProduct = new Processed_Product
                    {
                        Amount = (int)amount,
                        Expiration_Date = expirationDate,
                        Id_Product = 1,
                        Production_Date = DateTime.Now
                    };
                    await _ctx.Processed_Product.AddAsync(processedProduct, cancellationToken);
                    await _ctx.SaveChangesAsync(cancellationToken);

                    var product = _ctx.Product.Find(_idBread);
                    product.Stock += (int)amount;
                    await _ctx.SaveChangesAsync(cancellationToken);

                    await transaction.CommitAsync(cancellationToken);
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<BakeryProcessedProduct>> GetProcessedProductionAsyn(CancellationToken cancellationToken)
        {
            var products = await (from item in _ctx.Processed_Product
                                  orderby item.Production_Date
                                  select new BakeryProcessedProduct
                                  {
                                      Amoung = item.Amount,
                                      ExpirationDate = item.Expiration_Date,
                                      ProductionDate = item.Production_Date
                                  }).ToListAsync(cancellationToken);
            return products;
        }

        public async Task<IEnumerable<Product>> GetInventoryAsyn(CancellationToken cancellationToken)
        {
            var products = await (from item in _ctx.Product select item).ToListAsync(cancellationToken);
            return products;
        }
    }
}