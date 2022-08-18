using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class BakeryInventoryController : ControllerBase
    {
        private readonly IBakeryInventoryService _bakeryInventoryService;

        public BakeryInventoryController(IBakeryInventoryService bakeryInventoryService)
        {
            _bakeryInventoryService = bakeryInventoryService ?? throw new ArgumentNullException(nameof(bakeryInventoryService));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterBreadProduction(float quantity, DateTime expirationDate, CancellationToken cancellationToken = default)
        {
            BakeryResponse result = null;
            try
            {
                result = await _bakeryInventoryService.RegisterBreadProductionAsync(quantity, expirationDate, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetProduction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBreadProductionAsync(DateTime? expirationDate, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bakeryInventoryService.GetProcessedProductionAsyn(expirationDate, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Gets full inventory
        /// </summary>
        /// <param name="idProduct">id product.</param>
        /// <param name="cancellationToken">Transaction cancellation token.</param>
        /// <returns>full product list information</returns>
        [HttpGet("GetInventory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInventoryAsync(int? idProduct, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _bakeryInventoryService.GetInventoryAsyn(idProduct, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}