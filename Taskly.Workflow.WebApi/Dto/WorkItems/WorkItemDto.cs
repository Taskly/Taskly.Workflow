using Taskly.Workflow.Domain;

namespace Taskly.Workflow.WebApi.Dto.WorkItems
{
    public class WorkItemDto
    {
        public WorkItemDto(WorkItem model)
        {
            Id = model.Id;
            Title = model.Title;
            Description = model.Description;
            Status = new WorkItemStatusDto(model.Status);
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public WorkItemStatusDto Status { get; set; }
    }
}
