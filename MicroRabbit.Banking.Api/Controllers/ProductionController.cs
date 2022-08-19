using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductionController : ControllerBase
    {
        private readonly IProductionService _productiontService;
        public ProductionController(IProductionService productiontService)
        {
            _productiontService = productiontService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductionTransfer productionTransfer)
        {
            _productiontService.Transfer(productionTransfer);
            return Ok(productionTransfer);
        }

    }

}