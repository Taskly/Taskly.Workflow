namespace Taskly.Workflow.Domain
{
    public class WorkItem
    {
        public WorkItem(string projectId, string title, string description, WorkItemStatus status)
            : this(string.Empty, projectId, title, description, status)
        {
        }

        private WorkItem(string id, string projectId, string title, string description, WorkItemStatus status)
        {
            Id = id;
            ProjectId = projectId;
            Title = title;
            Description = description;
            Status = status;
        }

        public string Id { get; }

        public string ProjectId { get; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public WorkItemStatus Status { get; private set; }

        public void UpdateInfo(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void ChangeStatus(WorkItemStatus status)
        {
            Status = status;
        }
    }
}
