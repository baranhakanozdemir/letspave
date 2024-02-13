using LetsPave.Core.Models;
using LetsPave.Core.ServiceInterfaces;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using System.Text;

namespace LetsPave.Web.Services
{
    public class SaleServiceClient : ISaleService
    {
        private readonly string _baseUrl;
        public SaleServiceClient(IConfiguration configuration) 
        {
            _baseUrl = configuration["ApiUrl"];
        }

        public Task<IBaseResponse<Guid>> Add(ISale model, string userName, Guid transactionScopeId = default)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Guid>> Delete(Guid id, string userName, Guid transactionScopeId = default)
        {
            throw new NotImplementedException();
        }

        public Task<ISale> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ISale>> GetAll()
        {
            var result=new List<ISale>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = await client.GetAsync("/api/sales");
                var json=await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Sale>>(json);
                if (data != null)
                {
                    data.ForEach(result.Add);
                }                
            }
            return result;
        }

        public Task<DataTable> GetAllData(string tableName)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ProductCategorySaleItem>> GetCategoryRegionSeasonReport(ProductCategorySaleItem request)
        {
            var result = new List<ProductCategorySaleItem>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = await client.PostAsync("/api/sales",
                    new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ProductCategorySaleItem>>(json);
                return data;
            }
            
        }

        public async Task<SaleLookupItem> GetSaleLookupItem()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = await client.GetAsync("/api/sales/GetSaleLookupItem");
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<SaleLookupItem>(json);
                return data;
            }
        }

        public Task<IBaseResponse<Guid>> Update(Guid id, ISale model, string userName, Guid transactionScopeId = default)
        {
            throw new NotImplementedException();
        }

        public Task<ModelValidator> Validate(ISale model)
        {
            throw new NotImplementedException();
        }

        public Task<ModelValidator> ValidateDelete(ISale model)
        {
            throw new NotImplementedException();
        }

        public Task<ModelValidator> ValidateUpdate(Guid id, ISale model)
        {
            throw new NotImplementedException();
        }
    }
}
