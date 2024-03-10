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
        public RTDataContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-4KETQLO\\SQLEXPRESS;Initial Catalog=RegressionTesting;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }
}
