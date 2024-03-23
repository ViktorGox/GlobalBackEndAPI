using GlobalBackEndAPI.DatabaseCreation.Attributes;

namespace GlobalBackEndAPI.RegressionTesting.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Step
    {
        [PrimaryKey]
        public int StepId { get; set; }
        [ForeignKey("Test", "TestId", "ON DELETE CASCADE")]
        public Test TestId { get; set; }
        public int StepNr { get; set; }
        public string Label { get; set; }
        [Nullable]
        public string? Log { get; set; }
        [Nullable]
        public string? Description { get; set; }
        [DefaultValue(0)]
        public int Weight { get; set; }
        [DefaultValue(false)]
        public bool Completion { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
