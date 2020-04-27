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

        public string Title { get; private set; }

        public string Description { get; private set; }

        public WorkItemStatus Status { get; private set; }

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void ChangeStatus(WorkItemStatus status)
        {
            Status = status;
        }
    }
}
