using Azure;
using Azure.Data.Tables;

namespace BlazorTables.Data
{
    public class PersonEntity : Person, ITableEntity
    {
        public string PartitionKey { get; set; } = nameof(Person);
        public string RowKey { get => Id; set => Id = value; }
        public DateTimeOffset? Timestamp { get; set; } = DateTimeOffset.UtcNow;
        public ETag ETag { get; set; }
    }
}
