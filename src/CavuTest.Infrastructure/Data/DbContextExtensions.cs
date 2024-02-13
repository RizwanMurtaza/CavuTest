using CavuTest.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CavuTest.Infrastructure.Data
{
    public static class DbContextExtensions
    {
        public static void InitializeDbContext(
            this IServiceCollection services, IConfiguration configuration,
            DatabaseProvider provider)
        {
            var assemblyName = typeof(ApplicationDbContext).Assembly.GetName().Name;
            switch (provider)
            {
                case DatabaseProvider.MsSql:
                    {
                        var dbConnectionString = configuration.GetConnectionString("SqlServerConnectionString");
                        services.AddDbContext<ApplicationDbContext>(options =>
                                options.UseSqlServer(dbConnectionString, optionsBuilder => optionsBuilder.MigrationsAssembly(assemblyName)),
                            ServiceLifetime.Transient
                        );
                        break;
                    }
                case DatabaseProvider.Mysql:
                    {

                        var dbConnectionString = configuration.GetConnectionString("MySqlServerConnectionString");
                        services.AddDbContext<ApplicationDbContext>(options =>
                        {
                            options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString),
                                optionsBuilder => optionsBuilder.MigrationsAssembly(assemblyName));

                        }, ServiceLifetime.Transient);
                        break;
                    }
                case DatabaseProvider.InMemory:
                    {
                        //// Not Tested
                        services.AddDbContext<ApplicationDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("Test");

                        });
                        break;
                    }
            }
        }
    }
}