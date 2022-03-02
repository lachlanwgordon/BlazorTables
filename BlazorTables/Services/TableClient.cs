using Azure;
using Azure.Data.Tables;

namespace BlazorTables.Services
{
    public class TableClient<T> : TableClient where T : class, ITableEntity, new()
    {
        public TableClient(string connectionString) : base(connectionString, nameof(T))
        {
        }

        public override Response<T> GetEntity<T>(string partitionKey, string rowKey, IEnumerable<string> select = null, CancellationToken cancellationToken = default)
        {
            return base.GetEntity<T>(partitionKey, rowKey, select, cancellationToken);
        }
    }
}
