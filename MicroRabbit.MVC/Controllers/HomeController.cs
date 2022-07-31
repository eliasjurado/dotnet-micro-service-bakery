using MicroRabbit.MVC.Models;
using MicroRabbit.MVC.Models.Dto;
using MicroRabbit.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransferService _transferService;
        public HomeController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel model)
        {
            TransferDto transferDto = new TransferDto()
            {
                FromAccount = model.FromAccount,
                ToAccount = model.ToAccount,
                TransferAmount = model.TransferAmount,
            };
            await _transferService.Transfer(transferDto);
            return View("Index");
        }
    }
}
