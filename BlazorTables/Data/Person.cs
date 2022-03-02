using Azure.Data.Tables;

namespace BlazorTables.Data
{
    public class Person// : ITableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
