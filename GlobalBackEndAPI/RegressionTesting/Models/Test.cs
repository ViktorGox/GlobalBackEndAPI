using GlobalBackEndAPI.DatabaseCreation;
using GlobalBackEndAPI.DatabaseCreation.Attributes;

namespace GlobalBackEndAPI.RegressionTesting.Models
{
    public class Test : ITableGeneration
    {
        [PrimaryKey]
        public int TestId { get; set; }
        public string? Name { get; set; }
        [Nullable]
        public string? Description { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string TableGenerationQuery()
        {
            return "CREATE TABLE Test (" +
                   "TestId INT IDENTITY(1,1) PRIMARY KEY," +
                   "Name NVARCHAR(255) NOT NULL," +
                   "Description NVARCHAR(255) NULL," +
                   "LastUpdate DATE DEFAULT GETDATE()," +
                   "CreatedOn DATE DEFAULT GETDATE()" +
                   ");";
        }
    }
}