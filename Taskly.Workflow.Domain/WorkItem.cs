namespace Taskly.Workflow.Domain
{
    public class WorkItem
    {
        public WorkItem(string projectId, string title, string description, WorkItemStatus status)
        {
            ProjectId = projectId;
            Title = title;
            Description = description;
            Status = status;
        }

        public string Id { get; private set; }

        public string ProjectId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public WorkItemStatus Status { get; private set; }
    }
}
