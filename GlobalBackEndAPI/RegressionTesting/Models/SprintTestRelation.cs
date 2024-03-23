using GlobalBackEndAPI.DatabaseCreation.Attributes;

namespace GlobalBackEndAPI.RegressionTesting.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class SprintTestRelation
    {
        [ForeignKey("Sprint", "SprintId", "ON DELETE CASCADE")]
        public Sprint Sprint { get; set; }
        [ForeignKey("Test", "TestId", "ON DELETE CASCADE")]
        public Test Test { get; set; }
        [ForeignKey("Status", "StatusId")]
        [DefaultValue(1)]
        public Status Status { get; set; }
        [ForeignKey("User", "UserId", "ON DELETE SET NULL")]
        [Nullable]
        public User User { get; set; }
        [Nullable]
        public DateTime? CompletionDate { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
