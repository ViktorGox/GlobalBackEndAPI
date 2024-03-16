using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using GlobalBackEndAPI.DatabaseCreation;
using GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator;

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
            _ = new QueryGenerator(DataFetcher.FetchData("GlobalBackEndAPI.RegressionTesting.Models"));

            // TODO: DROP THEM FIRST
            Assembly assembly = Assembly.GetExecutingAssembly();

            string targetNamespace = "GlobalBackEndAPI.RegressionTesting.Models";

            var modelTypes = assembly.GetTypes().Where(t => t.Namespace == targetNamespace && !t.IsInterface && !t.IsAbstract);

            // TODO: Definitely needs refactoring.

            foreach (var type in modelTypes)
            {
                // Useless instance is created, but that will be resolved when the dynamic table creation is implemented.
                if (Activator.CreateInstance(type) is ITableGeneration startUpInstance)
                {
                    using (var dbContext = new RTDataContext())
                    {
                        string tableQuery = startUpInstance.TableGenerationQuery();
                        string fullQuery = "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'" + type.Name +"') AND type in (N'U'))\n" + tableQuery;
                        dbContext.Database.ExecuteSqlRaw(fullQuery);
                    }
                }
            }
        }
    }
}
