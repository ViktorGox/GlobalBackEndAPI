﻿namespace GlobalBackEndAPI.RegressionTesting.Models
{
    public class Test
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}