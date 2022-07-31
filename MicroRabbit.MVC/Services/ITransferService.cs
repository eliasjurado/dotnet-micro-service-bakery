using MicroRabbit.MVC.Models.Dto;

namespace MicroRabbit.MVC.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDto transfer);
    }
}
