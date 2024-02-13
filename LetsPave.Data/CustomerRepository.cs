using LetsPave.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LetsPave.Data
{
    public class CustomerRepository : SqlRepository<ICustomer, Guid>
    {
        public CustomerRepository(DbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
