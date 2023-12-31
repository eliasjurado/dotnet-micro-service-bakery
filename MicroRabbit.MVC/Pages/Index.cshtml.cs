﻿using MicroRabbit.MVC.Models;
using MicroRabbit.MVC.Models.Dto;
using MicroRabbit.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroRabbit.MVC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITransferService _transferService;
        public IEnumerable<TransferProductionLogViewModel>? TransferLogs { get; set; }
        public IndexModel(ITransferService transferService)
        {
            _transferService = transferService;
        }

        public async Task OnGet()
        {
            TransferLogs = await _transferService.GetTransfer();

        }
        public async Task<IActionResult> OnPost(TransferProductionDto transferDto)
        {
            await _transferService.Transfer(transferDto);
            return RedirectToPage("Index");
        }
    }
}