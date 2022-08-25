using Mango.Services.OrderAPI.Models;
using Mango.Services.OrderAPI.Repository;
using Mango.Services.OrderAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.OrderAPI.Controllers
{
    [Route("api/sell")]
    public class SellAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;


        public SellAPIController(IOrderRepository productRepository, IProductService productService)
        {
            _orderRepository = productRepository;
            this._response = new ResponseDto();
            _productService = productService;
        }

        [HttpPost]
        //[Authorize]
        [Route("RegisterSell")]
        public async Task<object> RegisterSellAsync([FromBody] SellHeaderDto sell)
        {
            try
            {
                //GetProductAvailableAsync FROM PRODUCT-->idProduct: 8
                int idProduct = sell.ProductId;
                var inventory = await _productService.GetProductAvailableAsync<int>(idProduct);
                var newSell = new SellHeader
                { FirstName = sell.FirstName, IdSellHeader = sell.IdSellHeader, UserId = sell.UserId,
                SellDetails = new List<SellDetails> 
                { new SellDetails { Count = sell.Count, IdSellHeader = sell.IdSellHeader, Price = sell.Price, ProductId = sell.ProductId, Id = sell.IdSellHeader} },
                SellTime = sell.SellTime
                };
                _response.IsSuccess = await _orderRepository.AddSell(newSell);
                //IF IsSuccess == TRUE, UpdateProductStockAsync FROM PRODUCT-->amount,idProduct
                _response.DisplayMessage = _response.IsSuccess ? "Sell have been saved" : "Sell can't be saved";
                
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        //[Authorize]
        [Route("RegisterSell1")]
        public async Task<object> RegisterSell1Async( SellHeaderDto sell)
        {
            try
            {
                //GetProductAvailableAsync FROM PRODUCT-->idProduct: 8
                int idProduct = sell.ProductId;
                var inventory = await _productService.GetProductAvailableAsync<int>(idProduct);
                var newSell = new SellHeader
                {
                    FirstName = sell.FirstName,
                    IdSellHeader = sell.IdSellHeader,
                    UserId = sell.UserId,
                    SellDetails = new List<SellDetails>
                { new SellDetails { Count = sell.Count, IdSellHeader = sell.IdSellHeader, Price = sell.Price, ProductId = sell.ProductId, Id = sell.IdSellHeader} },
                    SellTime = sell.SellTime
                };
                _response.IsSuccess = await _orderRepository.AddSell(newSell);
                //IF IsSuccess == TRUE, UpdateProductStockAsync FROM PRODUCT-->amount,idProduct
                _response.DisplayMessage = _response.IsSuccess ? "Sell have been saved" : "Sell can't be saved";

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}