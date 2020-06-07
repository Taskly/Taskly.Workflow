using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskly.Workflow.Domain
{
    public interface IProjectsRepository
    {
        Task<List<Project>> GetProjects();

        Task<Project> GetProject(string id);

        Task<Project> SaveProject(Project project);
    }
}
