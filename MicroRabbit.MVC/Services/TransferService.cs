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

        public async Task<IEnumerable<TransferProductionLogViewModel>?> GetTransfer()
        {
            try
            {
                var uri = "https://localhost:5004/api/TransferProduction";
                var response = await _apiClient.GetAsync(uri);
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<TransferProductionLogViewModel>>(body);
                response.EnsureSuccessStatusCode();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task Transfer(TransferProductionDto transferDto)
        {
            try
            {
                var uri = "https://localhost:5002/api/Production";
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
    }
}
