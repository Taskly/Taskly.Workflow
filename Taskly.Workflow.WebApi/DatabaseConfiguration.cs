using Microsoft.Extensions.DependencyInjection;
using Taskly.Workflow.WebApi.Config;
using Taskly.Workflow.WebApi.Database;

namespace Taskly.Workflow.WebApi
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
