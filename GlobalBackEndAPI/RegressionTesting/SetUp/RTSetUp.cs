using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using GlobalBackEndAPI.DatabaseCreation;
using GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator;
using CustomConsole;
using GlobalBackEndAPI.DatabaseCreation.Adapters;

namespace GlobalBackEndAPI.RegressionTesting.SetUp
{
    public class RTSetUp : ISetUp
    {
        private string? _connectionString;
        public void Configure(WebApplicationBuilder builder)
        {
            _connectionString = builder.Configuration.GetConnectionString("RegressionTesting");

            RTDataContext.ConnectionString = _connectionString;

            builder.Services.AddScoped<ITestRepository, TestRepository>();
            builder.Services.AddScoped<ISprintRepository, SprintRepository>();
            builder.Services.AddDbContext<RTDataContext>(options =>
            {
                options.UseSqlServer(_connectionString);
            });
        }

        public void InitializeDB()
        {
            TableQueryGenerator queryGenerator = new(DataFetcher.FetchData("GlobalBackEndAPI.RegressionTesting.Models"), TypeAdapter.Instance, CustomInfoAdapter.Instance);
            List<string> mainQueries = queryGenerator.TableMainQueries();

            foreach (string query in mainQueries)
            {
                RTDataContext.ExecuteSqlTableCreation(query);
            }

            List<string> alterQueries = queryGenerator.TableAlterQueries();
            foreach (string query in alterQueries)
            {
                RTDataContext.ExecuteSqlRaw(query);
            }
        }
    }
}
