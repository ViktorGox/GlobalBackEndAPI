namespace GlobalBackEndAPI.RegressionTesting.DTO
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class StepDTO
    {
        public int StepId { get; set; }
        public int StepNr { get; set; }
        public string Label { get; set; }
        public string? Log { get; set; }
        public string? Description { get; set; }
        public int Weight { get; set; }
        public bool Completion { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
