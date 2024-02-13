namespace LetsPave.Core.Models
{
    public interface ISale: ICoreDomainModel<Guid>
    {
        Order Order { get; set; }
        Customer Customer { get; set; }
        Product Product { get; set; }
        double Price { get; set; }
        double Quantity { get; set; }
        double Discount { get; set; }
        double Profit { get; set; }
    }

    public class Sale : CoreDomainModel<Guid>, ISale
    {
        public required Order Order { get; set; }
        public required Customer Customer { get; set; }
        public required Product Product { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double Profit { get; set; }
    }
}
