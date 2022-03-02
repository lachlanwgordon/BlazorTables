using Azure.Data.Tables;

namespace BlazorTables.Data
{
    public class Person// : ITableEntity
    {
        public String Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
