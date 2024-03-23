﻿using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.Repositories;
using Microsoft.EntityFrameworkCore;
using GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator;
using GlobalBackEndAPI.DatabaseCreation.Adapters;
using CustomConsole;

namespace GlobalBackEndAPI.RegressionTesting.SetUp
{
    public class RTSetUp : ISetUp
    {
        private string? _connectionString;
        public void Configure(WebApplicationBuilder builder)
        {
            _connectionString = builder.Configuration.GetConnectionString("RegressionTesting");

            RTDataContext.ConnectionString = _connectionString;

            builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
            builder.Services.AddScoped<ISprintRepository, SprintRepository>();
            builder.Services.AddScoped<IStatusRepository, StatusRepository>();
            builder.Services.AddScoped<IStepRepository, StepRepository>();
            builder.Services.AddScoped<ITestRepository, TestRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();

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
