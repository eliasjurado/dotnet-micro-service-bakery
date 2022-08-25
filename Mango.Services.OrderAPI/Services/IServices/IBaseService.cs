using Mango.Services.OrderAPI.Models;
using System;
using System.Threading.Tasks;

namespace Mango.Services.OrderAPI.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
