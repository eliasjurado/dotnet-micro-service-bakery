using Mango.Services.ProductAPI.Test.Fixtures;
using Xunit;

namespace Mango.Services.ProductAPI.Test
{
    public class ProcessProductControllerTest : IClassFixture<ProductRepositoryFixture>
    {
        public readonly ProductRepositoryFixture _fixture;

        public ProcessProductControllerTest(ProductRepositoryFixture fixture)
        {
            _fixture = fixture;
        }
        /*
        public ProcessProductAPIController(IProductRepository productRepository)
        public async Task<object> RegisterBreadProductionAsync([FromBody] ProcessProductDto processProduct)
        public async Task<object> GetProductAvailableAsync(int idProduct)
        public async Task<object> UpdateProductStockAsync(double amount, int idProduct)
        */
    }
}
