using GlobalBackEndAPI.DatabaseCreation;

namespace GlobalBackEndAPI.RegressionTesting.Models
{
    public class Test : ITableGeneration
    {
        public int TestId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreatedOn { get; set; }

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