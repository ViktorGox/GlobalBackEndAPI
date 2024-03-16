using GlobalBackEndAPI.DatabaseCreation;
using GlobalBackEndAPI.DatabaseCreation.Attributes;

namespace GlobalBackEndAPI.RegressionTesting.Models
{
    public class User : ITableGeneration
    {
        [PrimaryKey]
        public int UserId { get; set; }
        [Unique]
        public string? Email { get; set; }
        [Unique]
        public string? Username { get; set; }
        public string? Password { get; set; }
        [ForeignKey("Role", "RoleId")]
        public Role? Role { get; set; }
        public string TableGenerationQuery()
        {
            return "CREATE TABLE User (" +
                   "UserId INT IDENTITY(1,1) PRIMARY KEY," +
                   "Email NVARCHAR(255) NOT NULL," +
                   "Username NVARCHAR(255) NOT NULL," +
                   "Password NVARCHAR(255) NOT NULL," +
                   "RoleId INT NOT NULL," +
                   "CONSTRAINT FK_User_Role FOREIGN KEY (RoleId) REFERENCES Role(RoleId)" +
                   ");";
        }
    }
}
