using Mango.Services.OrderAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mango.Services.OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);

        Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);

        Task<bool> AddSell(SellHeader sellHeader);

        Task<IEnumerable<SellInformation>> GetSellsAsync();
    }
}