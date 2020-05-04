using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskly.Workflow.Domain
{
    public interface IWorkItemsRepository
    {
        Task<List<WorkItem>> GetWorkItemsByProject(Guid projectId);

        Task<WorkItem> GetWorkItem(Guid id);

        Task<WorkItem> SaveWorkItem(WorkItem workItem);

        Task DeleteWorkItem(Guid id);
    }
}
