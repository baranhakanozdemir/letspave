using LetsPave.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPave.Data
{
    public class SaleRepository : CsvRepository<ISale, Guid>
    {
        public SaleRepository(ILogger<SaleRepository> logger, IConfiguration config) : base(config, logger)
        {

        }

    }
}
