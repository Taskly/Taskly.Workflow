using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WorkflowService.WebApi
{
    internal static class SwaggerConfiguration
    {
        internal static void AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "WorkflowService API",
                    Version = "v1.0",
                    Description = "Taskly Workflow Service API"
                });
            });
        }

        internal static void UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger(c => { c.RouteTemplate = "/api-docs/swagger/{documentName}/swagger.json"; });
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/api-docs/swagger/v1.0/swagger.json", "WorkflowService API v1.0"); });
        }
    }
}
