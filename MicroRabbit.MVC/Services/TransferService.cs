using MicroRabbit.MVC.Models.Dto;
using Newtonsoft.Json;
using System.Text;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;

        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task Transfer(TransferDto transferDto)
        {
            var uri = "https://localhost:5002/api/Banking";
            var transferContent = new StringContent(
                JsonConvert.SerializeObject(transferDto),
                Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
