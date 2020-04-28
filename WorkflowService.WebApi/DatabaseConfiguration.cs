using Microsoft.Extensions.DependencyInjection;
using WorkflowService.WebApi.Config;
using WorkflowService.WebApi.Database;

namespace WorkflowService.WebApi
{
    internal static class DatabaseConfiguration
    {
        internal static void AddDatabaseRepositories(this IServiceCollection services, AppConfig appConfig)
        {
            DbContext dbContext = new DbContext(appConfig.Mongo);

            services.AddSingleton(dbContext);

            // services.AddSingleton<IIdRepository, IdRepository>();
        }
    }
}
