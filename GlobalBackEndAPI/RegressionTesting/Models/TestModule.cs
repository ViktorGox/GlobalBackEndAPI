using GlobalBackEndAPI.DatabaseCreation.Attributes;
using Microsoft.EntityFrameworkCore;

namespace GlobalBackEndAPI.RegressionTesting.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [Keyless]
    public class TestModule
    {
        [ForeignKey("Module", "ModuleId")]
        public Module Module { get; set; }
        [ForeignKey("Test", "TestId")]
        public Test Test { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
