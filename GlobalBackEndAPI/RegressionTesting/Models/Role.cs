using GlobalBackEndAPI.DatabaseCreation;
using GlobalBackEndAPI.DatabaseCreation.Attributes;

namespace GlobalBackEndAPI.RegressionTesting.Models
{
    public class Role : ITableGeneration
    {
        [PrimaryKey]
        public int RoleId { get; set; }
        [Unique]
        public string? Name { get; set; }
        public string TableGenerationQuery()
        {
            return "CREATE TABLE Role (" +
                   "RoleId INT IDENTITY(1,1) PRIMARY KEY," +
                   "Name NVARCHAR(255) NOT NULL" +
                   ");";
        }
    }
}
