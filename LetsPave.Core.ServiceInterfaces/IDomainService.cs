
using LetsPave.Core.Models;
using System.Data;

namespace LetsPave.Core.ServiceInterfaces
{
    public interface IDomainService<M, T> where M : ICoreDomainModel<T>
    {
        Task<ICollection<M>> GetAll();
        Task<DataTable> GetAllData(string tableName);
        Task<M> Get(T id);
        Task<IBaseResponse<T>> Add(M model, string userName, Guid transactionScopeId = default);
        Task<IBaseResponse<T>> Delete(T id, string userName, Guid transactionScopeId = default);
        Task<IBaseResponse<T>> Update(T id, M model, string userName, Guid transactionScopeId = default);
        Task<ModelValidator> Validate(M model);
        Task<ModelValidator> ValidateUpdate(T id, M model);
        Task<ModelValidator> ValidateDelete(M model);
    }
}
