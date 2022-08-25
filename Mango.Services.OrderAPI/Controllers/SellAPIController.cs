﻿using Mango.Services.OrderAPI.Models;
using Mango.Services.OrderAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mango.Services.OrderAPI.Controllers
{
    [Route("api/sell")]
    public class SellAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IOrderRepository _orderRepository;

        public SellAPIController(IOrderRepository productRepository)
        {
            _orderRepository = productRepository;
            this._response = new ResponseDto();
        }

        [HttpPost]
        //[Authorize]
        [Route("RegisterSell")]
        public async Task<object> RegisterSellAsync([FromBody] SellHeader sell)
        {
            try
            {
                //GetProductAvailableAsync FROM PRODUCT-->idProduct: 8
                _response.IsSuccess = await _orderRepository.AddSell(sell);
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