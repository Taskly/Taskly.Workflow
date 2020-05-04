using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Taskly.Workflow.Domain;

namespace Taskly.Workflow.WebApi.Database
{
    public class WorkItemsRepository : IWorkItemsRepository
    {
        public WorkItemsRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WorkItem>> GetWorkItemsByProject(string projectId)
        {
            List<WorkItem> workItems = await _dbContext.WorkItems.Find(x => x.ProjectId == projectId).ToListAsync();
            return workItems;
        }

        public async Task<WorkItem> GetWorkItem(string id)
        {
            WorkItem workItem = await _dbContext.WorkItems.Find(x => x.Id == id).FirstOrDefaultAsync();
            return workItem;
        }

        public async Task<WorkItem> SaveWorkItem(WorkItem workItem)
        {
            var replaceOptions = new ReplaceOptions
            {
                IsUpsert = true
            };

            await _dbContext.WorkItems.ReplaceOneAsync(x => x.Id == workItem.Id, workItem,
                replaceOptions);
            return workItem;
        }

        public async Task DeleteWorkItem(string id)
        {
            await _dbContext.WorkItems.DeleteOneAsync(x => x.Id == id);
        }

        private readonly DbContext _dbContext;
    }
}
