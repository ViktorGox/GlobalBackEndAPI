using GlobalBackEndAPI.DatabaseCreation.Attributes;

namespace GlobalBackEndAPI.RegressionTesting.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class TestModule
    {
        [ForeignKey("Test", "TestId", "ON DELETE CASCADE")]
        public Test TestId { get; set; }
        [ForeignKey("Module", "ModuleId", "ON DELETE CASCADE")]
        public Module ModuleId { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
