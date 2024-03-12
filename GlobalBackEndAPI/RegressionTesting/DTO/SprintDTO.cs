namespace GlobalBackEndAPI.RegressionTesting.DTO
{
    public class SprintDTO
    {
        public int SprintId { get; set; }
        public required string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
