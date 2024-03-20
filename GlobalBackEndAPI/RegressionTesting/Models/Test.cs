using GlobalBackEndAPI.DatabaseCreation.Attributes;

namespace GlobalBackEndAPI.RegressionTesting.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Test
    {
        [PrimaryKey]
        public int TestId { get; set; }
        public string Name { get; set; }
        [Nullable]
        public string? Description { get; set; }
        [DefaultValue("Now")]
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        [DefaultValue("Now")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}