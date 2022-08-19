using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Transfer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferProductionController : ControllerBase
    {
        private readonly ITransferProductionService _transferProductionService;

        public TransferProductionController(ITransferProductionService transferProductionService)
        {
            _transferProductionService = transferProductionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransferProductionLog>> Get()
        {
            return Ok(_transferProductionService.GetTransferProductionLogs());
        }
    }
}