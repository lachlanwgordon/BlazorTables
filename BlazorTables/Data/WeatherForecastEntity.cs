using Azure;
using Azure.Data.Tables;

namespace BlazorTables.Data
{
    public class WeatherForecastEntity : WeatherForecast, ITableEntity
    {
        public string PartitionKey { get; set; } = nameof(WeatherForecast);
        public string RowKey { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset? Timestamp { get; set; } = DateTimeOffset.UtcNow;
        public ETag ETag { get; set; }
    }
}
