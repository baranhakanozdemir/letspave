using LetsPave.Core.ServiceInterfaces;
using LetsPave.Core.Services;
using LetsPave.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPave.Tests
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
            });
            services.AddSingleton(typeof(ISaleService), typeof(SaleService));
            services.AddSingleton(typeof(SaleRepository));

        }

        public void Configure(IApplicationBuilder appBuilder)
        {

        }
    }
}
