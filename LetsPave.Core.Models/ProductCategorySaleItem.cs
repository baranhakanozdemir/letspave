namespace LetsPave.Core.Models
{
    public class ProductCategorySaleItem
    {
        public string? Category { get; set; }
        public string? Season { get; set; }
        public string? Region { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }
        public double Profit { get; set; }
    }
}
