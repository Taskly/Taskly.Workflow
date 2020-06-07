using Microsoft.Extensions.DependencyInjection;
using Taskly.Workflow.Application;
using Taskly.Workflow.Application.Config;
using Taskly.Workflow.Domain;

namespace Taskly.Workflow.WebApi
{
    internal static class DatabaseConfiguration
    {
        internal static void AddDatabaseRepositories(this IServiceCollection services, AppConfig appConfig)
        {
            AppDbContext dbContext = new AppDbContext(appConfig.Mongo);

            services.AddSingleton(dbContext);
            services.AddSingleton<IProjectsRepository, ProjectsRepository>();
            services.AddSingleton<IWorkItemsRepository, WorkItemsRepository>();
        }
    }
}
