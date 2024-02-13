using LetsPave.Core.ServiceInterfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace LetsPave.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        private readonly ISaleService _saleService;
        private readonly IConfiguration _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public IntegrationTests()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
            var serviceProvider = new DependencyResolverHelpercs(webHost);
            _saleService = serviceProvider.GetService<ISaleService>();
        }

        [TestMethod]
        public async Task TestCsvRepoDataTable()
        {
            var data = await _saleService.GetAllData("Sales");            
        }

        [TestMethod]
        public async Task TestCsvRepoAllSales()
        {
            var data = await _saleService.GetAll();

        }
    }
}