using System.Threading.Tasks;

namespace Mango.Services.OrderAPI.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetProductAvailableAsync<T>(int idProduct);
        Task<T> UpdateProductStockAsync<T>(double amount, int idProduct);
    }
}
