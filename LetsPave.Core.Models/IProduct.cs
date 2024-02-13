
namespace LetsPave.Core.Models
{
    public interface IProduct: ICoreDomainModel<Guid>
    {
        string ProductId { get; set; } 
        string ProductName { get; set; }
        string Category { get; set; }
        string SubCategory { get; set; }
    }

    public class Product : CoreDomainModel<Guid>, IProduct
    {
        public required string ProductId { get; set; }
        public required string ProductName { get; set; }
        public required string Category { get; set; }
        public required string SubCategory { get; set; }
    }
}
