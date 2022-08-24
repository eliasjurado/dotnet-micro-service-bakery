using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public async Task<ProcessProductDto> RegisterBreadProductionAsync(ProcessProductDto processProductDto)
        {
            ProcessProduct newProcessProduct = _mapper.Map<ProcessProductDto, ProcessProduct>(processProductDto);
            _db.ProcessProducts.Add(newProcessProduct);

            await _db.SaveChangesAsync();
            return _mapper.Map<ProcessProduct, ProcessProductDto>(newProcessProduct);
        }

        public async Task<double> GetProductAvailableAsync(int idProduct)
        {
            Product product = await _db.Products.Where(x => x.ProductId == idProduct).FirstOrDefaultAsync();
            return product.Stock;
        }

        public async Task<ProductDto> UpdateProductStockAsync(double amount, int idProduct)
        {
            Product product = await _db.Products.Where(x => x.ProductId == idProduct).FirstOrDefaultAsync();

            product.Stock -= amount;
            _db.Products.Update(product);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}