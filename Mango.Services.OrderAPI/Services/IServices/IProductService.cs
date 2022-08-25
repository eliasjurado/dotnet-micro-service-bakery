using System.Threading.Tasks;

namespace Mango.Services.OrderAPI.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetProductAvailableAsync<T>(int idProduct);
        //Task<T> GetAllProductsAsync<T>(string token);
        //Task<T> GetProductByIdAsync<T>(int id, string token);
        //Task<T> CreateProductAsync<T>(ProductDto productDto, string token);
        //Task<T> UpdateProductAsync<T>(ProductDto productDto, string token);
        //Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
