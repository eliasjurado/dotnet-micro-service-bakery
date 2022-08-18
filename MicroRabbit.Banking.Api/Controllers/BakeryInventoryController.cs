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
        public async Task<IActionResult> RegisterBreadProduction(int quantity, DateTime expirationDate, CancellationToken cancellationToken)
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
    }

}