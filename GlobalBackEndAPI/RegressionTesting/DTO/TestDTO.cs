namespace GlobalBackEndAPI.RegressionTesting.DTO
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class TestDTO
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}