using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorkflowService.Domain
{
    public interface IWorkItemsRepository
    {
        Task<List<WorkItem>> GetWorkItemsByProject(string projectId);

        Task<WorkItem> GetWorkItem(string id);

        Task SaveWorkItem(WorkItem workItem);
    }
}
