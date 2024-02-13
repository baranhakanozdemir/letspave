using LetsPave.Core.Models;
using LetsPave.Core.ServiceInterfaces;
using LetsPave.Data;
using System.Data;

namespace LetsPave.Core.Services
{
    public class DomainService<M, T> : IDomainService<M, T> where M : ICoreDomainModel<T>
    {
        private readonly IRepository<M, T> _repository;

        public DomainService(IRepository<M, T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<ICollection<M>> GetAll()
        {
            var result = await _repository.GetAll();
            return result;
        }

        public virtual async Task<M> Get(T id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IBaseResponse<T>> Add(M model, string userName, Guid transactionScopeId = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IBaseResponse<T>> Delete(T id, string userName, Guid transactionScopeId = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IBaseResponse<T>> Update(T id, M model, string userName, Guid transactionScopeId = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ModelValidator> Validate(M model)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ModelValidator> ValidateUpdate(T id, M model)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ModelValidator> ValidateDelete(M model)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<DataTable> GetAllData(string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
