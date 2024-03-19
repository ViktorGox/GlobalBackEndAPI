using GlobalBackEndAPI.DatabaseCreation.Attributes;

namespace GlobalBackEndAPI.RegressionTesting.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Sprint
    {
        [PrimaryKey]
        public int SprintId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
