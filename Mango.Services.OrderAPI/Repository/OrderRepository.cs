using Mango.Services.OrderAPI.DbContexts;
using Mango.Services.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Mango.Services.OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;

        public OrderRepository(DbContextOptions<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddSell(SellHeader sellHeader)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            _db.SellHeaders.Add(sellHeader);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SellInformation>> GetSellsAsync()
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            
            var result = await (from sell in _db.SellHeaders
                          join det in _db.SellDetails
                          on sell.IdSellHeader equals det.SellHeaderIdSellHeader
                          orderby sell.SellTime
                          select new SellInformation
                          {
                              Count = det.Count,
                              FirstName = sell.FirstName,
                              Price = det.Price,
                              ProductId = det.ProductId,
                              SellTime = sell.SellTime,
                              UserId = sell.UserId
                          }).ToListAsync();
            return result;
        }

        #region MyRegion

        public async Task<bool> AddOrder(OrderHeader orderHeader)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            _db.OrderHeaders.Add(orderHeader);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            var orderHeaderFromDb = await _db.OrderHeaders.FirstOrDefaultAsync(u => u.OrderHeaderId == orderHeaderId);
            if (orderHeaderFromDb != null)
            {
                orderHeaderFromDb.PaymentStatus = paid;
                await _db.SaveChangesAsync();
            }
        }

        #endregion MyRegion
    }
}