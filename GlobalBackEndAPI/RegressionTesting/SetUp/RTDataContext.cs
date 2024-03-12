using GlobalBackEndAPI.RegressionTesting.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalBackEndAPI.RegressionTesting.SetUp
{
    /// <summary>
    /// RT stands for Regression Testing
    /// </summary>
    public class RTDataContext : DbContext
    {
        public DbSet<Test> Test { get; set; }
        public DbSet<Sprint> Sprint { get; set; }

        private static string? s_connectionString;

        /// <summary>
        /// Connection string for manual querying. Cannot be change after being set.
        /// </summary>
        public static string? ConnectionString
        {
            private get { return s_connectionString; }
            set
            {
                if (string.IsNullOrWhiteSpace(s_connectionString) && !string.IsNullOrWhiteSpace(value))
                {
                    s_connectionString = value;
                }
            }
        }

        // Required by the system.
        public RTDataContext(DbContextOptions<RTDataContext> options) : base(options) { }

        /// <summary>
        /// For doing manual querying.
        /// </summary>
        public RTDataContext()
        {
            if (string.IsNullOrWhiteSpace(s_connectionString))
            {
                throw new Exception("Connection string was not set up. Set property, probably should be done in the SetUp class");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(s_connectionString);
            }
        }
    }
}
