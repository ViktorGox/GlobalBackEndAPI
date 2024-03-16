using GlobalBackEndAPI.DatabaseCreation;
using GlobalBackEndAPI.DatabaseCreation.Attributes;

namespace GlobalBackEndAPI.RegressionTesting.Models
{
    public class Sprint : ITableGeneration
    {
        [PrimaryKey]
        public int SprintId { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string TableGenerationQuery()
        {
            return "CREATE TABLE Sprint (" +
                   "SprintId INT IDENTITY(1,1) PRIMARY KEY," +
                   "Title NVARCHAR(255) NOT NULL," +
                   "StartDate DATE NOT NULL," +
                   "EndDate DATE NOT NULL," +
                   ");";
        }
    }
}
