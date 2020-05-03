namespace Taskly.Workflow.WebApi.Dto.WorkItems
{
    public class WorkItemCreateDto
    {
        public WorkItemCreateDto(string title, string description, WorkItemStatusDto status)
        {
            Title = title;
            Description = description;
            Status = status;
        }

        public string ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public WorkItemStatusDto Status { get; set; }
    }
}
