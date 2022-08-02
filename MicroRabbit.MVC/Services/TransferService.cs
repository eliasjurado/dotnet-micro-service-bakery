using MicroRabbit.MVC.Models;
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
            try
            {
                var uri = "https://localhost:5002/api/Banking";
                var transferContent = new StringContent(
                    JsonConvert.SerializeObject(transferDto),
                    Encoding.UTF8, "application/json");
                var response = await _apiClient.PostAsync(uri, transferContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public async Task<IEnumerable<TransferLogViewModel>?> GetTransfer()
        {
            try
            {
                var uri = "https://localhost:5004/api/Transfer";
                var response = await _apiClient.GetAsync(uri);
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<TransferLogViewModel>>(body);
                response.EnsureSuccessStatusCode();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
