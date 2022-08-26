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
        [Route("RegisterSell")]
        public async Task<object> RegisterSellAsync([FromBody] SellHeader sell)
        {
            try
            {
                _response.IsSuccess = false;
                var itemToBuy = (from item in sell.SellDetails select item).FirstOrDefault();
                var inventory = await _productService.GetProductAvailableAsync<ResponseDto>(itemToBuy.ProductId);

                if (inventory.IsSuccess && (((Int64)inventory.Result) > itemToBuy.Count))
                {
                    var updateInventory = await _productService.UpdateProductStockAsync<ResponseDto>(itemToBuy.Count, itemToBuy.ProductId);
                    if (updateInventory.IsSuccess)
                    {
                        var sellResult = await _orderRepository.AddSell(sell);
                        if (sellResult)
                        {
                            _response.IsSuccess = true;
                            _response.DisplayMessage = "Sell have been saved";
                        }
                        else
                            _response.DisplayMessage = "System couldn't update the inventory.";
                    }
                }
                else
                {
                    _response.DisplayMessage = "Out of stock";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("ShowSells")]
        public async Task<object> GetAsync()
        {
            try
            {
                _response.IsSuccess = true;
                _response.Result = await _orderRepository.GetSellsAsync();
                _response.DisplayMessage = "Sucessfull";
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