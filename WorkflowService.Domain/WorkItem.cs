namespace WorkflowService.Domain
{
    public class WorkItem
    {
        public WorkItem(string title, WorkItemStatus status)
            : this(title, string.Empty, status)
        {
        }

        public WorkItem(string title, string description, WorkItemStatus status)
        {
            Title = title;
            Description = description;
            Status = status;
        }

        public string Title { get; }

        public string Description { get; }

        public WorkItemStatus Status { get; }
    }
}
