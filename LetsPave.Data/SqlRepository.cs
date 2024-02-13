using LetsPave.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace LetsPave.Data
{
    public class SqlRepository<M, T> : IRepository<M, T> where M : ICoreDomainModel<T>
    {
        private readonly DbContext _context;
        private readonly ILogger _logger;

        public SqlRepository(DbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public virtual async Task<ICollection<M>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<M> Get(T id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IBaseResponse<T>> Add(M model)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IBaseResponse<T>> Update(M model)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IBaseResponse<T>> Delete(T id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllData(string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
