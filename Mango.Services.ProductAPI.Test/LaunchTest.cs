using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Mango.Services.ProductAPI.Test
{
    public class LaunchTest
    {
        [Fact]
        public void Main_IsLaunched()
        {
            string[] args = { };
            var result = Program.CreateHostBuilder(args);
            Assert.IsType<HostBuilder>(result);
        }

        [Fact]
        public void Startup_IsLaunched()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection()
                .Build();
            var result = new Startup(configuration);
            Assert.IsType<Startup>(result);
        }
    }
}
