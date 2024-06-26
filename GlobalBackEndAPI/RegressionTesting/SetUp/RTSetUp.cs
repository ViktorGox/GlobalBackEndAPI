﻿using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.Repositories;
using Microsoft.EntityFrameworkCore;
using GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator;
using GlobalBackEndAPI.DatabaseCreation.Adapters;
using Newtonsoft.Json;
using GlobalBackEndAPI.SetUp;

namespace GlobalBackEndAPI.RegressionTesting.SetUp
{
    public class RTSetUp : ISetUp
    {
        private string? _connectionString;
        public void Configure(WebApplicationBuilder builder)
        {
            JsonSerializer jsonSerializer = new();

            builder.Services.AddControllers();

            _connectionString = builder.Configuration.GetConnectionString("RegressionTesting");

            RTDataContext.ConnectionString = _connectionString;

            builder.Services.AddScoped<ITestRepository, TestRepository>();
            builder.Services.AddScoped<IModuleRepository, ModuleRepository>();

            builder.Services.AddDbContext<RTDataContext>(options =>
            {
                options.UseSqlServer(_connectionString);
            });
        }

        public void InitializeDB(string targetNamespace)
        {
            TableQueryGenerator queryGenerator = new(DataFetcher.FetchData(targetNamespace), TypeAdapter.Instance, CustomInfoAdapter.Instance);
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
