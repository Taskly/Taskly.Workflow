using Taskly.Workflow.Domain;

namespace Taskly.Workflow.WebApi.Dto.WorkItems
{
    public class WorkItemDto
    {
        public WorkItemDto(string title, string description, WorkItemStatusDto status)
        {
            Title = title;
            Description = description;
            Status = status;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public WorkItemStatusDto Status { get; private set; }
    }
}
