using GlobalBackEndAPI.RegressionTesting.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalBackEndAPI.RegressionTesting.Data
{
    /// <summary>
    /// RT stands for Regression Testing
    /// </summary>
    public class RTDataContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public RTDataContext(DbContextOptions<RTDataContext> options) : base(options) { }
    }
}
