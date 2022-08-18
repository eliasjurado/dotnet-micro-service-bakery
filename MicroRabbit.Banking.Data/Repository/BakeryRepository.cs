﻿using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Data.Repository
{
    public class BakeryRepository : IBakeryRepository
    {
        private BakeryDbContext _ctx;
        private const int _idButter = 3;
        private const int _idFluor = 2;
        private const int _idBread = 1;

        public BakeryRepository(BakeryDbContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
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
                var product = _ctx.Product.Find(_idFluor);
                product.Stock -= (int)Math.Ceiling(projectedFlour);
                await _ctx.SaveChangesAsync(cancellationToken);

                product = _ctx.Product.Find(_idButter);
                product.Stock -= (int)Math.Ceiling(projectedButter);
                await _ctx.SaveChangesAsync(cancellationToken);
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
                var processedProduct = new Processed_Product
                {
                    Amount = (int)amount,
                    Expiration_Date = expirationDate
                };
                await _ctx.Processed_Product.AddAsync(processedProduct, cancellationToken);

                var product = _ctx.Product.Find(_idBread);
                product.Stock += (int)amount;
                await _ctx.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}