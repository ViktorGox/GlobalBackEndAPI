using CustomConsole;
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
                throw new Exception("Connection string was not set up. Set the property, probably should be done in the SetUp class");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(s_connectionString);
            }
        }

        public static int ExecuteSqlRaw(string query)
        {
            using (var dbContext = new RTDataContext())
            {
                return dbContext.Database.ExecuteSqlRaw(query);
            }
        }

        public static void ExecuteSqlTableCreation(string query)
        {
            string[] words = query.Split(' ');
            string tableName = "";
            if (words.Length >= 3)
            {
                tableName = words[2];
            }
            CConsole.WriteWarning(query);
            string fullQuery = "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'" + tableName + "') AND type in (N'U')) " + query;
            ExecuteSqlRaw(fullQuery);
        }
    }
}