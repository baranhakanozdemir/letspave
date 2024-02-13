using LetsPave.Core.Models;
using LetsPave.Core.ServiceInterfaces;
using LetsPave.Data;

namespace LetsPave.Core.Services
{
    public class CustomerService : DomainService<ICustomer, Guid>, ICustomerService
    {
        public CustomerService(CustomerRepository repository) : base(repository)
        {

        }
    }
}
