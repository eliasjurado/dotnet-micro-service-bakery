using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class BakerySaleController : ControllerBase
    {
        private readonly IBakerySaleService _bakerySaleService;

        public BakerySaleController(IBakerySaleService bakerySaleService)
        {
            _bakerySaleService = bakerySaleService ?? throw new ArgumentNullException(nameof(bakerySaleService));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterSaleProduction(float quantity, float price, CancellationToken cancellationToken = default)
        {
            BakeryResponse result = null;
            try
            {
                result = await _bakerySaleService.RegisterSaleAsync(quantity, price, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(result);
            }
        }

    }
}