using LetsPave.Core.Models;
using System.Data;

namespace LetsPave.Data
{
    public interface IRepository<M, T> where M : ICoreDomainModel<T>
    {
        Task<ICollection<M>> GetAll();
        DataTable GetAllData(string tableName);
        Task<M> Get(T id);
        Task<IBaseResponse<T>> Add(M model);
        Task<IBaseResponse<T>> Update(M model);
        Task<IBaseResponse<T>> Delete(T id);
    }
}
