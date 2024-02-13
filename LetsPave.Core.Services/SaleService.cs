using LetsPave.Core.Models;
using LetsPave.Core.ServiceInterfaces;
using LetsPave.Data;
using Microsoft.Extensions.Logging;
using System.Data;

namespace LetsPave.Core.Services
{
    public class SaleService : DomainService<ISale, Guid>, ISaleService
    {
        private readonly SaleRepository _repository;
        private readonly ILogger _logger;
        public SaleService(SaleRepository repository, ILogger<SaleService> logger) : base(repository)
        {
            _repository=repository;
            _logger=logger;
        }

        public override async Task<DataTable> GetAllData(string tableName)
        {
            var data= _repository.GetAllData(tableName);
            return data;
        }

        public override async Task<ICollection<ISale>> GetAll()
        {
            var dataTable = _repository.GetAllData("Sales");
            var all = new List<ISale>();
            foreach (DataRow row in dataTable.Rows)
            {
                var sale = FromDataRow(row);
                all.Add(sale);
            }
            return all;
        }

        private Sale FromDataRow(DataRow row)
        {
            try
            {
                var sale = new Sale
                {
                    Product = new Product
                    {
                        ProductName = row["Product Name"].ToString(),
                        ProductId = row["Product ID"].ToString(),
                        Category = row["Category"].ToString(),
                        SubCategory = row["Sub-Category"].ToString()
                    },
                    Customer = new Customer
                    {
                        CustomerId = row["Customer ID"].ToString(),
                        CustomerName = row["Customer Name"].ToString(),
                        City = row["City"].ToString(),
                        Country = row["Country"].ToString(),
                        PostalCode = row["Postal Code"].ToString(),
                        Region = row["Region"].ToString(),
                        State = row["State"].ToString()
                    },
                    Order = new Order
                    {
                        OrderId = row["Order ID"].ToString(),
                        OrderDate = DateTime.Parse(row["Order Date"].ToString()),
                        ShipDate = DateTime.Parse(row["Ship Date"].ToString()),
                        ShipMode = Enum.Parse<ShipModes>(row["Ship Mode"].ToString().Replace(" ", ""))
                    },
                    Discount = double.Parse(row["Discount"].ToString()),
                    Price = double.Parse(row["Sales"].ToString()),
                    Profit = double.Parse(row["Profit"].ToString()),
                    Quantity = double.Parse(row["Quantity"].ToString())
                };

                return sale;
                
            }
            catch (Exception ex)
            {
                _logger.LogError
                    (
                       $"Unhandled Exception, message: {ex.Message}, " +
                       $"stack trace:{ex.StackTrace}, " +
                       $"inner exception: {(ex.InnerException == null ? "null" : ex.InnerException.Message)}"
                    );
                throw; // we should not make it silent here 
            }
        }

        public async Task<ICollection<ProductCategorySaleItem>> GetCategoryRegionSeasonReport(ProductCategorySaleItem request)
        {
            var all = await GetAll();


            var data = all
                .Where(s => string.IsNullOrEmpty(request.Category) || s.Product.Category == request.Category)
                .Where(s => string.IsNullOrEmpty(request.Region) || s.Customer.Region == request.Region)
                .Where(s => string.IsNullOrEmpty(request.State) || s.Customer.State == request.State)
                .Where(s => string.IsNullOrEmpty(request.City) || s.Customer.City == request.City)
                .Where(s => string.IsNullOrEmpty(request.Season) || GetMonths(request.Season).Contains(s.Order.OrderDate.Month));

            var query = data.GroupBy(s => new { s.Customer.Region, s.Customer.State, s.Customer.City, s.Product.Category, s.Order.OrderDate.Month })
                .Select(r=>new ProductCategorySaleItem
                {
                    Category=r.Key.Category,
                    Region=r.Key.Region,
                    State=r.Key.State,
                    City=r.Key.City,
                    Season= GetSeason(r.Key.Month),                    
                    Quantity=r.Sum(s => s.Quantity),
                    Profit=r.Sum (s => s.Profit),
                    Price = r.Sum(s => s.Price),
                    Discount=r.Sum (s => s.Discount)
                });
            return query.ToList();
        }

        public static string GetSeason(int Mont)
        {
            switch (Mont)
            {
                case 12:
                case 1:
                case 2:
                    return "Winter";

                case 3:
                case 4:
                case 5:
                    return "Spring";
                case 6:
                case 7:
                case 8:
                    return "Summer";
                case 9:
                case 10:
                case 11:
                    return "Fall";
                default:
                    return "Unknown";

            }
        }

        public static List<int> GetMonths(string season)
        {
            switch(season)
            {
                case "Winter": return new List<int> { 1, 2, 12 };
                case "Spring": return new List<int> { 3, 4, 5 };
                case "Summer": return new List<int> { 6, 7, 8 };
                case "Fall": return new List<int> { 9, 10, 11 };
                default:return new List<int>();
            }
            
        }

        public async Task<SaleLookupItem> GetSaleLookupItem()
        {
            var data = await GetAll();
            return new SaleLookupItem
            {
                Categories=data.Select(s=>s.Product.Category).Distinct().OrderBy(s=>s).ToList(),
                Regions= data.Select(s => s.Customer.Region).Distinct().OrderBy(s => s).ToList(),
                States= data.Select(s => s.Customer.State).Distinct().OrderBy(s => s).ToList(),
                Cities= data.Select(s => s.Customer.City).Distinct().OrderBy(s => s).ToList()
            };
        }
    }
}
