namespace GlobalBackEndAPI.RegressionTesting.DTO
{
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
}
