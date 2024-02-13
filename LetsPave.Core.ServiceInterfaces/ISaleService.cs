using LetsPave.Core.Models;

namespace LetsPave.Core.ServiceInterfaces
{
    public interface ISaleService : IDomainService<ISale, Guid>
    {
        Task<ICollection<ProductCategorySaleItem>> GetCategoryRegionSeasonReport(ProductCategorySaleItem request);
        Task<SaleLookupItem> GetSaleLookupItem();
    }
}
