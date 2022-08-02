using MicroRabbit.MVC.Models;
using MicroRabbit.MVC.Models.Dto;
using MicroRabbit.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroRabbit.MVC.Pages.Transfer
{
    public class IndexModel : PageModel
    {
        private readonly ITransferService _transferService;
        public IEnumerable<TransferLogViewModel>? TransferLogs { get; set; }
        public IndexModel(ITransferService transferService)
        {
            _transferService = transferService;
        }

        public async Task OnGet()
        {
            TransferLogs = await _transferService.GetTransfer();

        }
        public async Task<IActionResult> OnPost(TransferDto transferDto)
        {
            await _transferService.Transfer(transferDto);
            return RedirectToPage("Index");
        }
    }
}
