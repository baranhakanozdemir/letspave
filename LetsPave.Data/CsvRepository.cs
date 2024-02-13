using CsvHelper;
using LetsPave.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;

namespace LetsPave.Data
{
    public class CsvRepository<M, T> : IRepository<M, T> where M : ICoreDomainModel<T>
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        public CsvRepository(IConfiguration config, ILogger logger)
        {
            _logger = logger;
            _configuration = config;
        }
        public Task<IBaseResponse<T>> Add(M model)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<T>> Delete(T id)
        {
            throw new NotImplementedException();
        }

        public Task<M> Get(T id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<M>> GetAll()
        {

            throw new NotImplementedException();
        }

        public Task<IBaseResponse<T>> Update(M model)
        {
            throw new NotImplementedException();
        }

        private static DataTable Read(string fileName, string tablename)
        {
            DataTable dt = new DataTable(tablename);
            using (StreamReader sr = new StreamReader(fileName))
            {
                using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    foreach (var header in csv.HeaderRecord)
                    {
                        dt.Columns.Add(header);
                    }
                    while (csv.Read())
                    {
                        var row = dt.NewRow();
                        foreach (DataColumn column in dt.Columns)
                        {
                            row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                        }
                        dt.Rows.Add(row);
                    }
                }
            }
            return dt;
        }

        public DataTable GetAllData(string tablename)
        {
            var dataFileName = _configuration["CSVFile"];
            if (string.IsNullOrEmpty(dataFileName))
            {
                _logger.LogError("CSV File setting has no value");
                return new DataTable(tablename); // we can return exception if this is requirement
            }
            if (!File.Exists(dataFileName))
            {
                _logger.LogError($"CSV File cannot be found at {dataFileName}");
                return new DataTable(tablename); // we can return exception if this is requirement
            }
            var data = Read(dataFileName, tablename);

            return data;
        }
    }
}
