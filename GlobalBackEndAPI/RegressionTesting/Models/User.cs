using GlobalBackEndAPI.DatabaseCreation.Attributes;

namespace GlobalBackEndAPI.RegressionTesting.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class User
    {
        [PrimaryKey]
        public int UserId { get; set; }
        [Unique]
        public string Email { get; set; }
        [Unique]
        public string Username { get; set; }
        public string Password { get; set; }
        [ForeignKey("Role", "RoleId")]
        public Role? Role { get; set; }
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
