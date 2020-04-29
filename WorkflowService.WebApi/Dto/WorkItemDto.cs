using WorkflowService.Domain;

namespace WorkflowService.WebApi.Dto
{
    public class WorkItemDto
    {
        public WorkItemDto(WorkItem model)
        {
            Title = model.Title;
            Description = model.Description;
            Status = model.Status;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public WorkItemStatus Status { get; private set; }
    }
}
