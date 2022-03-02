using Azure.Data.Tables;

namespace BlazorTables.Services
{
    public interface ITableService<T>
    {
        Task<List<T>> GetAllAsync();
        Task SaveAsync(T item);
    }

    public class TableService<T> : ITableService<T> where T : class, ITableEntity, new()
    {
        private TableClient tableClient;

        public TableService(TableClient tableClient)
        {
            this.tableClient = tableClient;
            tableClient.CreateIfNotExists();
        }

        public Task<List<T>> GetAllAsync()
        {
            //investigate async api
            var items = tableClient.Query<T>().ToList();
            return Task.FromResult(items); 
        }

        public async Task SaveAsync(T item)
        {
            await tableClient.UpsertEntityAsync(item);

        }
    }
}
