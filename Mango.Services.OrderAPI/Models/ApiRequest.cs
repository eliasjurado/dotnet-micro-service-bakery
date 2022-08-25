using static Mango.Services.OrderAPI.Models.Util;

namespace Mango.Services.OrderAPI.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }

    public static class Util
    {

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public static string ProductAPIBase { get; set; }
    }
}