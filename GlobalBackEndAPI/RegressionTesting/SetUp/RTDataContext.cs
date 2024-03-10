using GlobalBackEndAPI.RegressionTesting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace GlobalBackEndAPI.RegressionTesting.SetUp
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
