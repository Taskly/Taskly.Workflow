using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskly.Workflow.Domain
{
    public interface IWorkItemsRepository
    {
        Task<List<WorkItem>> GetWorkItemsByProject(string projectId);

        Task<WorkItem> GetWorkItem(string id);

        Task SaveWorkItem(WorkItem workItem);

        Task DeleteWorkItem(string id);
    }
}
