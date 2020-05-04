using System;
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

        public async Task<List<WorkItem>> GetWorkItemsByProject(Guid projectId)
        {
            List<WorkItem> workItems = await _dbContext.WorkItems.Find(x => x.ProjectId == projectId).ToListAsync();
            return workItems;
        }

        public async Task<WorkItem> GetWorkItem(Guid id)
        {
            WorkItem workItem = await _dbContext.WorkItems.Find(x => x.Id == id).FirstOrDefaultAsync();
            return workItem;
        }

        public async Task<WorkItem> SaveWorkItem(WorkItem workItem)
        {
            if (workItem.Id == Guid.Empty)
            {
                await _dbContext.WorkItems.InsertOneAsync(workItem);
            }
            else
            {
                await _dbContext.WorkItems.ReplaceOneAsync(x => x.Id == workItem.Id, workItem);
            }

            return workItem;
        }

        public async Task DeleteWorkItem(Guid id)
        {
            await _dbContext.WorkItems.DeleteOneAsync(x => x.Id == id);
        }

        private readonly DbContext _dbContext;
    }
}
