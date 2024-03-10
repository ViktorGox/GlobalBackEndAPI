using CustomConsole;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GlobalBackEndAPI.RegressionTesting.SetUp
{
    public class RTSetUp : ISetUp
    {
        public void Configure(WebApplicationBuilder builder)
        {
            CConsole.WriteSuccess(this, " was created!");
            builder.Services.AddScoped<ITestRepository, TestRepository>();
            builder.Services.AddDbContext<RTDataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("RegressionTesting"));
            });
        }

        public void InitializeDB()
        {
        }
    }
}
